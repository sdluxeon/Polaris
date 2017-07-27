using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Polaris.WebForms.Models
{
    public class NoDiscovery : IAutoDiscovery
    {
        public IEnumerable<Sperm> Discover(Bitmap image)
        {
            return new List<Sperm>();
        }

        public int GetAvarageSpermArea(Bitmap bitmap)
        {
            return 0;
        }
    }

    public class Spermogram : IDisposable
    {
        public static Spermogram Empty { get { return new Spermogram(); } }

        private IAutoDiscovery discovery;

        private Bitmap originalImage;

        private int avarageSpermArea;

        Spermogram() : this(new Bitmap(1, 1), new NoDiscovery())
        {
        }

        public Spermogram(Bitmap image, IAutoDiscovery discovery) : this(image, discovery, new List<Sperm>())
        {

        }

        public Spermogram(Bitmap image, IAutoDiscovery discovery, List<Sperm> sperm)
        {
            this.discovery = discovery;
            Spermatosoids = new Observable<List<Sperm>>(new List<Sperm>());
            originalImage = image;
            DisplayImage = new Observable<Bitmap>(((Bitmap)originalImage.Clone()));
            if (sperm.Any())
                ShowAll();
            avarageSpermArea = CaluclateAvarageSpermArea();
        }


        public Observable<Bitmap> DisplayImage { get; private set; }

        public Observable<List<Sperm>> Spermatosoids { get; private set; }

        public void Mark(Point point, SpermType spermType)
        {
            var radius = Math.Sqrt(avarageSpermArea / Math.PI);
            var circle = point.GetCircle(radius);
            var newSperm = new Sperm(circle.ToList(), point, spermType);
            AddSperm(newSperm);

            ShowAll();
        }

        public void UnMark(Point point)
        {
            var closest = Spermatosoids.State.ToList().OrderBy(x => point.DistanceTo(x.Center)).ToList();
            foreach (var item in closest)
            {
                if (point.IsInside(item.Points))
                {
                    RemoveSperm(item);
                    ShowAll();
                    return;
                }
            }
        }

        public void Discover()
        {
            lock (originalImage)
            {
                using (var localCopy = originalImage.Clone() as Bitmap)
                {
                    var result = discovery.Discover(localCopy);
                    Spermatosoids = Spermatosoids.Change(result.ToList());
                }
            }
            ShowAll();//Test
        }

        public void ShowAll()
        {
            lock (originalImage)
            {
                var newDisplayImage = originalImage.Clone() as Bitmap;

                using (var graphics = Graphics.FromImage(newDisplayImage))
                {
                    foreach (var item in Spermatosoids.State)
                    {
                        using (var pen = new Pen(SpermogramColors.Border[item.SpermType], 2))
                        {
                            graphics.DrawPolygon(pen, item.Points.Select(x => new System.Drawing.Point(x.X, x.Y)).ToArray());
                        }
                    }
                }
                DisplayImage = DisplayImage.Change(newDisplayImage);
            }
        }

        public void Dispose()
        {
            originalImage.Dispose();
            DisplayImage.Dispose();
            Spermatosoids.Dispose();
        }

        private void AddSperm(Sperm sperm)
        {
            var newSpermatosoids = new List<Sperm>(Spermatosoids.State);
            newSpermatosoids.Add(sperm);
            Spermatosoids = Spermatosoids.Change(newSpermatosoids);
        }

        private void RemoveSperm(Sperm sperm)
        {
            var newSpermatosoids = new List<Sperm>(Spermatosoids.State);
            newSpermatosoids.Remove(sperm);
            Spermatosoids = Spermatosoids.Change(newSpermatosoids);
        }

        private int CaluclateAvarageSpermArea()
        {
            using (var localCopy = originalImage.Clone() as Bitmap)
            {
                var area = discovery.GetAvarageSpermArea(localCopy);
                if (area == 0)
                    return 200;
                else
                    return area;
            }
        }
    }
}
