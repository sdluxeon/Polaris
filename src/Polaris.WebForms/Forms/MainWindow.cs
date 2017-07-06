using Polaris.WebForms.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
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
                    statusBarLabel.Text = text;

                });
            });

            SpermogramaBrowser.Global.Images.Subscribe(x =>
            {
                imagesListView.InvokeAsync(view =>
                {
                    view.Items.Clear();
                    view.Items.AddRange(x.Select(file => new FileInfo(file).FullName).OrderBy(n => n).ToArray());
                });
            });

            imagesListView.SelectedIndexChanged += ImagesListView_SelectedIndexChanged;
            //SpermogramaBrowser.Global.SelectedImage.Subscribe(x =>
            //{
            //    imagesListView.InvokeAsync((lv) =>
            //    {
            //        var itemToSelect = imagesListView.Items.IndexOf(x);
            //        if (itemToSelect >= 0)
            //        {
            //            //imagesListView.Items[itemToSelect] = true;
            //            //  imagesListView.Select();
            //        }
            //    });

            //});

            SpermogramaBrowser.Global.Scan(@"D:\SampleImages");

        }

        private void ImagesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //blobsBrowser1.SetImage((Bitmap)Bitmap.FromFile(imagesListView.SelectedItem.ToString()));
            pictureBox1.Image = (Bitmap)Bitmap.FromFile(imagesListView.SelectedItem.ToString());
        }

        private void browseDirectory_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                browseDirectoryLabel.Text = folderBrowserDialog.SelectedPath;
                SpermogramaBrowser.Global.Scan(folderBrowserDialog.SelectedPath).ContinueWith((c) => { this.InvokeAsync(x => { this.Enabled = true; }); });
            }

        }
    }
}
