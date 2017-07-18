using Accord;
using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Math.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Polaris.WebForms.Models
{
    public class AccordAreaBasedAutoDiscovery : IAutoDiscovery
    {
        private IDeviationProvider provider;

        public AccordAreaBasedAutoDiscovery()
        {
            provider = new AsyncDeviationProvider();
        }

        public int GetAvarageSpermArea(Bitmap bitmap)
        {
            var blobFinder = new BlobFinder(provider);
            var deviation = blobFinder.FindAreaDeviation(bitmap);
            return (int)deviation.Median;
        }

        public IEnumerable<Sperm> Discover(Bitmap image)
        {
            var classificator = new SpermClassificator();
            var blobFinder = new BlobFinder(provider);
            var blobs = blobFinder.FindBlobsByArea(image);
            GrahamConvexHull grahamScan = new GrahamConvexHull();
            foreach (var blob in blobs)
            {
                List<IntPoint> leftEdge = new List<IntPoint>();
                List<IntPoint> rightEdge = new List<IntPoint>();
                List<IntPoint> topEdge = new List<IntPoint>();
                List<IntPoint> bottomEdge = new List<IntPoint>();

                // collect edge points
                blobFinder.BlobCounter.GetBlobsLeftAndRightEdges(blob, out leftEdge, out rightEdge);
                blobFinder.BlobCounter.GetBlobsTopAndBottomEdges(blob, out topEdge, out bottomEdge);

                // find convex hull
                List<IntPoint> edgePoints = new List<IntPoint>();
                edgePoints.AddRange(leftEdge);
                edgePoints.AddRange(rightEdge);

                List<IntPoint> hull = grahamScan.FindHull(edgePoints);

                var points = hull.Select(x => new Point(x.X, x.Y)).ToList();
                var center = new Point(blob.CenterOfGravity.X, blob.CenterOfGravity.Y);
                blobFinder.BlobCounter.ExtractBlobsImage(image, blob, false);
                var blobBitmap = blob.Image.ToManagedImage(true);
                var spermType = classificator.Classify(blobBitmap);
                yield return new Sperm(points, center, spermType);
            }
        }

        private class BlobFinder
        {
            IDeviationProvider provider;

            public BlobFinder(IDeviationProvider provider)
            {
                this.provider = provider;
                BlobCounter = new BlobCounter();
                BlobCounter.FilterBlobs = true;
                BlobCounter.MinHeight = 5;
                BlobCounter.MinWidth = 5;

                ColorFilter = new ColorFiltering();
                ColorFilter.Red = new IntRange(0, 30);
                ColorFilter.Green = new IntRange(0, 50);
                ColorFilter.Blue = new IntRange(0, 30);
                ColorFilter.FillOutsideRange = false;
            }

            public BlobCounter BlobCounter { get; private set; }

            public ColorFiltering ColorFilter { get; private set; }

            public IEnumerable<Blob> FindBlobsByArea(Bitmap bitmap)
            {
                var blobs = FindBlobs(bitmap);
                var areas = blobs.Select(x => (double)x.Area).ToArray();
                Deviation deviation = provider.GetDeviation(areas, 85);
                return blobs.Where(x => deviation.FallsInStandartDeviation(x.Area));
            }

            public Deviation FindAreaDeviation(Bitmap bitmap)
            {
                var blobs = FindBlobs(bitmap);
                var areas = blobs.Select(x => (double)x.Area).ToArray();
                Deviation deviation = provider.GetDeviation(areas, 85);
                return deviation;
            }

            private IEnumerable<Blob> FindBlobs(Bitmap bitmap)
            {
                var rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapData bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, bitmap.PixelFormat);

                ColorFilter.ApplyInPlace(bitmapData);
                BlobCounter.ProcessImage(bitmapData);

                Blob[] blobs = BlobCounter.GetObjectsInformation();
                bitmap.UnlockBits(bitmapData);
                return blobs;
            }
        }
    }
}
