using Polaris.WebForms.Models;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Polaris.WebForms.Forms
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            ProgramStatus.Global.AddObserver(text =>
            {
                statusBar.InvokeAsync(x =>
                {
                    statusBarLabel.Text = DateTime.UtcNow.ToString();

                });
            });
        }
    }
}
