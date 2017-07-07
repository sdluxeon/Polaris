using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Polaris.WebForms.Models
{
    public static class PointExtensions
    {
        public static IEnumerable<Point> GetCircle(this Point self, double radius)
        {
            for (int angle = 0; angle < 360; angle++)
            {
                var x1 = self.X + radius * Math.Cos(angle * (Math.PI / 180));
                var y1 = self.Y + radius * Math.Sin(angle * (Math.PI / 180));
                yield return new Point((int)x1, (int)y1);
            }
        }

        public static double DistanceTo(this Point self, Point point)
        {
            return Math.Sqrt(Math.Pow(self.X - point.X, 2) + Math.Pow(self.Y - point.Y, 2));
        }

        public static System.Drawing.Point ToDrawingPoint(this Point self)
        {
            return new System.Drawing.Point(self.X, self.Y);
        }

        public static bool IsInside(this Point self, List<Point> hull)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddPolygon(hull.Select(x => x.ToDrawingPoint()).ToArray());
                return gp.IsVisible(self.ToDrawingPoint());
            }
        }
    }
}
