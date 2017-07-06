using Polaris.WebForms.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Polaris.WebForms.Forms
{
    public partial class MainWindow : Form
    {
        private ProgramStatus status;

        private ImageBrowser spermogramaBrowser;

        public MainWindow(ProgramStatus status, ImageBrowser imageBrowser, SpermogramaViewer spermogramaViewer)
        {
            this.status = status;
            this.spermogramaBrowser = imageBrowser;
            InitializeComponent();

            status.AddObserver(text =>
            {
                this.ChangeStatus(text);
            });

            imageBrowser.Images.OnChange(images =>
            {
                this.BrowseFiles(images);
            });

            imagesListView.SelectedIndexChanged += ImagesListView_SelectedIndexChanged;

            imageBrowser.SelectedImage.OnChange(x =>
            {
                spermogramaViewer.View(x);
            });

            spermogramaViewer.DisplayImage.OnChange(bitmap =>
            {
                this.UpdateImage(bitmap);
            });

            spermogramaViewer.Spermatosoids.OnChange(x =>
            {
                if (x != null)
                {
                    this.lblRed.InvokeAsync(lbl => { lbl.Text = x.Count(xx => xx.SpermType == SpermType.Red).ToString(); });
                    this.lblGreen.InvokeAsync(lbl => { lbl.Text = x.Count(xx => xx.SpermType == SpermType.Green).ToString(); });
                    this.lblOrange.InvokeAsync(lbl => { lbl.Text = x.Count(xx => xx.SpermType == SpermType.Orange).ToString(); });
                }
            });

            //imageBrowser.Scan(@"D:\SampleImages");
        }

        private void ImagesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            spermogramaBrowser.Select(imagesListView.SelectedItem.ToString());
        }

        private void browseDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                DisableUI();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    browseDirectoryLabel.Text = folderBrowserDialog.SelectedPath;
                    spermogramaBrowser.Scan(folderBrowserDialog.SelectedPath).ContinueWith((c) => EnableUI());
                }
                else
                {
                    EnableUI();
                }
            }
            catch (Exception ex)
            {
                EnableUI();
            }
        }

        private void DisableUI()
        {
            this.InvokeAsync(x =>
            {
                this.Enabled = false;
            });
        }

        private void EnableUI()
        {
            this.InvokeAsync(x =>
            {
                this.Enabled = true;
            });
        }

        private void UpdateImage(Image img)
        {
            pictureBox.InvokeAsync(pb =>
            {
                pb.Image = img;
            });
        }

        private void ChangeStatus(string text)
        {
            statusBar.InvokeAsync(x =>
            {
                statusBarLabel.Text = text;
            });
        }

        private void BrowseFiles(IEnumerable<string> images)
        {
            imagesListView.InvokeAsync(view =>
            {
                view.Items.Clear();
                view.Items.AddRange(images.OrderBy(fileName => fileName).ToArray());
            });
        }
    }
}
