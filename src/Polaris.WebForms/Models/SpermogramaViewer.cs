using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Polaris.WebForms.Models
{
    public class SpermogramaViewer
    {
        AccordAreaBasedAutoDiscovery discovery;

        private Bitmap originalImage;

        public SpermogramaViewer()
        {
            discovery = new AccordAreaBasedAutoDiscovery();
            DisplayImage = new Observable<Bitmap>(null);
            Spermatosoids = new Observable<List<Sperm>>(null);
        }

        public Observable<Bitmap> DisplayImage { get; private set; }

        public Observable<List<Sperm>> Spermatosoids { get; private set; }

        public void View(string imageLocation)
        {
            originalImage = null;
            if (imageLocation != null)
            {
                originalImage = (Bitmap)Bitmap.FromFile(imageLocation);
                DisplayImage = DisplayImage.Change((Bitmap)originalImage.Clone());
                Discover();//test
                ShowAll();
            }
        }


        public void Discover()
        {
            if (originalImage == null)
                return;
            lock (originalImage)
            {
                var localCopy = originalImage.Clone() as Bitmap;
                var result = discovery.Discover(localCopy);
                Spermatosoids = Spermatosoids.Change(result.ToList());
            }
        }

        public void ShowAll()
        {
            if (originalImage == null)
                return;
            lock (originalImage)
            {
                var localCopy = originalImage.Clone() as Bitmap;
                Dictionary<SpermType, Color> borderColors = new Dictionary<SpermType, Color>();
                borderColors.Add(SpermType.Unknown, Color.LightCyan);
                borderColors.Add(SpermType.Green, Color.White);
                borderColors.Add(SpermType.Red, Color.Red);
                borderColors.Add(SpermType.Orange, Color.Blue);
                using (var graphics = Graphics.FromImage(localCopy))
                {
                    foreach (var item in Spermatosoids.State)
                    {
                        using (var pen = new Pen(borderColors[item.SpermType], 2))
                        {
                            graphics.DrawPolygon(pen, item.Points.Select(x => new System.Drawing.Point(x.X, x.Y)).ToArray());
                        }
                    }
                }
                DisplayImage = DisplayImage.Change(localCopy);
            }
        }
    }
}
