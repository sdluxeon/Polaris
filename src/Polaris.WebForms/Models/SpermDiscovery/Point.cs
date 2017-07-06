using System;

namespace Polaris.WebForms.Models
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(float x, float y)
        {
            X = Convert.ToInt32(x);
            Y = Convert.ToInt32(y);
        }

        public int X { get; private set; }

        public int Y { get; private set; }
    }
}
