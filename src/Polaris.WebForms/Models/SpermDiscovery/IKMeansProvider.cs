using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polaris.WebForms.Models
{
    public interface IDeviationProvider
    {
        Deviation GetDeviation(double[] numbers, int deviationPercent);
    }
    public class AsyncDeviationProvider : IDeviationProvider
    {
        public Deviation GetDeviation(double[] numbers, int deviationPercent)
        {
            var avg = new AvarageDeviationMeans();
            var ballancedKMeans = new AvarageDeviationMeans();
            Deviation dev = null;
            var task = Task.Run(() => dev = ballancedKMeans.GetDeviation(numbers, deviationPercent));
            if (Task.WhenAny(task, Task.Delay(3000)).Result == task)
            {
                return dev;
            }
            else
            {
                return avg.GetDeviation(numbers, deviationPercent);
            }
        }
    }
    public class Deviation
    {
        public double Median { get; private set; }
        private double begin;
        private double end;

        public Deviation(double median, double begin, double end)
        {
            this.Median = median;
            this.begin = begin;
            this.end = end;
        }

        public bool FallsInStandartDeviation(double number)
        {
            if (begin <= number && number <= end)
                return true;
            else
                return false;
        }
    }

    public class AvarageDeviationMeans : IDeviationProvider
    {
        public Deviation GetDeviation(double[] numbers, int deviationPercent)
        {
            var median = numbers.Average();
            var begin = median - (median * (deviationPercent / 100d));
            var end = median + (median * (deviationPercent / 100d));
            return new Deviation(median, begin, end);
        }
    }


    public class BalancedKMeansDeviation : IDeviationProvider
    {
        public Deviation GetDeviation(double[] inputArea, int deviationPercent)
        {
            var numbers = inputArea.Distinct().ToArray();
            var balancedKMeans = new Accord.MachineLearning.BalancedKMeans(3);
            balancedKMeans.MaxIterations = 1;
            var matrix = new double[numbers.Length][];
            for (int i = 0; i < numbers.Length; i++)
            {
                matrix[i] = new double[] { numbers[i] }; ;
            }

            var result = balancedKMeans.Learn(matrix);//stuck on third calculation;
            var biggestCentroid = result.Decide(matrix).GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            var median = balancedKMeans.Centroids[biggestCentroid].First();
            var begin = median - (median * (deviationPercent / 100d));
            var end = median + (median * (deviationPercent / 100d));

            return new Deviation(median, begin, end);
        }
    }
}
