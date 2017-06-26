using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polaris.WebForms.Forms
{
    public static class ControlExtensions
    {
        delegate void InvokeAsyncDelegate(Control control);
        public static void InvokeAsync<T>(this T control, Action<T> method) where T : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(method, new object[] { control });
            }
            else
            {
                method(control);
            }
        }
    }
}
