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
    public class SpermogramaViewer
    {
        public Observable<Spermogram> CurrentSpermograma { get; private set; }

        public SpermogramaViewer()
        {
            CurrentSpermograma = new Observable<Spermogram>(Spermogram.Empty);
        }

        public void View(string location)
        {
            var spermograma = Spermogram.Empty;
            if (location != null)
            {
                spermograma = new Spermogram((Bitmap)Bitmap.FromFile(location), new AccordAreaBasedAutoDiscovery());
            }
            CurrentSpermograma = CurrentSpermograma.Change(spermograma);
        }
    }
}
