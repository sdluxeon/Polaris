using System.Collections.Generic;
using System.Drawing;

namespace Polaris.WebForms.Models
{
    public static class SpermogramColors
    {
        public static Dictionary<SpermType, Color> Border;

        static SpermogramColors()
        {
            Border = new Dictionary<SpermType, Color>();
            Border.Add(SpermType.Unknown, Color.LightCyan);
            Border.Add(SpermType.Green, Color.Green);
            Border.Add(SpermType.Red, Color.Red);
            Border.Add(SpermType.Orange, Color.DarkOrange);
        }

    }
    public class SpermogramViewer
    {
        public Observable<Spermogram> CurrentSpermogram { get; private set; }

        public SpermogramViewer()
        {
            CurrentSpermogram = new Observable<Spermogram>(Spermogram.Empty);
        }

        public void View(string location)
        {
            var spermogram = Spermogram.Empty;
            if (location != null)
            {
                spermogram = new Spermogram((Bitmap)Bitmap.FromFile(location), new AccordAreaBasedAutoDiscovery());
            }
            CurrentSpermogram = CurrentSpermogram.Change(spermogram);
        }
    }
}
