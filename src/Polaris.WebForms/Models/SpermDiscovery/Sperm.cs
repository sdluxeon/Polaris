using System.Collections.Generic;

namespace Polaris.WebForms.Models
{
    public class Sperm
    {
        public Sperm(List<Point> points, Point center, SpermType spermType)
        {
            Points = points;
            Center = center;
            SpermType = spermType;
        }

        public List<Point> Points { get; private set; }

        public Point Center { get; private set; }

        public SpermType SpermType { get; private set; }
    }
}
