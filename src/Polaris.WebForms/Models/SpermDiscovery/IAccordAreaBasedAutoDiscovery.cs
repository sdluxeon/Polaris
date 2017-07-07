using System.Collections.Generic;
using System.Drawing;

namespace Polaris.WebForms.Models
{
    public interface IAutoDiscovery
    {
        IEnumerable<Sperm> Discover(Bitmap image);
        int GetAvarageSpermArea(Bitmap bitmap);
    }
}