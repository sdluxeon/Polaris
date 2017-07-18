using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace Polaris.WebForms.Models
{
    public class SpermClassificator
    {
        public SpermType Classify(Bitmap bitmap)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bitmap.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] r = new byte[bytes / 3];
            byte[] g = new byte[bytes / 3];
            byte[] b = new byte[bytes / 3];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            int count = 0;
            int stride = bmpData.Stride;

            for (int column = 0; column < bmpData.Height; column++)
            {
                for (int row = 0; row < bmpData.Width; row++)
                {
                    b[count] = (byte)(rgbValues[(column * stride) + (row * 3)]);
                    g[count] = (byte)(rgbValues[(column * stride) + (row * 3) + 1]);
                    r[count++] = (byte)(rgbValues[(column * stride) + (row * 3) + 2]);
                }
            }
            List<SpermType> types = new List<SpermType>();
            for (int i = 0; i < r.LongLength; i++)
            {
                types.Add(DiscoverType(Color.FromArgb(r[i], g[i], b[i])));
            }
            var groups = types.GroupBy(x => x);
            double red = (double)groups.Where(x => x.Key == SpermType.Red).SelectMany(x => x).Count();
            double green = (double)groups.Where(x => x.Key == SpermType.Green).SelectMany(x => x).Count();
            double orange = (double)groups.Where(x => x.Key == SpermType.Orange).SelectMany(x => x).Count();
            double total = red + green + orange;
            var percantageRed = red / total;
            var percantageGreen = green / total;
            var percantageOrange = orange / total;
            if (percantageRed >= 0.5d)
                return SpermType.Red;
            if (percantageGreen >= 0.5d)
                return SpermType.Green;
            if (percantageOrange >= 0.5d)
                return SpermType.Orange;
            return SpermType.Unknown;
        }
        private SpermType DiscoverType(Color argbColor)
        {
            if (argbColor.R == 0 && argbColor.G == 0 && argbColor.B == 0)
                return SpermType.Unknown;
            double total = argbColor.R + argbColor.G; //+ argbColor.B;
            double percantageRed = argbColor.R / total;
            double percantageGreen = argbColor.G / total;

            if (percantageRed >= 0.70d)//more than 70% red
                return SpermType.Red;
            if (percantageGreen >= 0.50d)//more than 50% green
                return SpermType.Green;
            if (Math.Abs(percantageRed - percantageGreen) < 0.5)//diff less than 50%
                return SpermType.Orange;
            return SpermType.Unknown;
        }

        //private SpermType DiscoverTypeNotUsed(Color argbColor)
        //{
        //    Dictionary<Color, int> colorDistances = new Dictionary<Color, int>();
        //    colorDistances.Add(Color.Green, ColorDiff(Color.FromArgb(0, 255, 0), argbColor));
        //    colorDistances.Add(Color.Yellow, ColorDiff(Color.Yellow, argbColor));
        //    colorDistances.Add(Color.Orange, ColorDiff(Color.Orange, argbColor));
        //    colorDistances.Add(Color.Red, ColorDiff(Color.FromArgb(255, 0, 0), argbColor));

        //    Dictionary<Color, SpermType> spermTypes = new Dictionary<Color, SpermType>();
        //    spermTypes.Add(Color.Green, SpermType.Green);
        //    spermTypes.Add(Color.Yellow, SpermType.Orange);
        //    spermTypes.Add(Color.Orange, SpermType.Orange);
        //    spermTypes.Add(Color.Red, SpermType.Red);

        //    var closestColor = colorDistances.OrderBy(x => x.Value).FirstOrDefault().Key;

        //    return spermTypes[closestColor];
        //}

        //private int ColorDiff(Color c1, Color c2)
        //{
        //    return (int)Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R)
        //                           + (c1.G - c2.G) * (c1.G - c2.G)
        //                           + (c1.B - c2.B) * (c1.B - c2.B));
        //}

    }
}
