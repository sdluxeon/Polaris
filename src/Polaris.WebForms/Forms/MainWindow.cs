using Polaris.WebForms.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Polaris.WebForms.Forms
{
    public partial class MainWindow : Form
    {
        private ProgramStatus status;

        private ImageBrowser imageBrowser;

        private SpermogramViewer spermogramaViewer;

        private SpermType currentMarker;

        public MainWindow(ProgramStatus status, ImageBrowser imageBrowser, SpermogramViewer spermogramaViewer)
        {
            InitializeComponent();
            this.currentMarker = SpermType.Green;
            this.status = status;
            this.imageBrowser = imageBrowser;
            this.spermogramaViewer = spermogramaViewer;
            btnGreenMarker.Click += btnGreenMarker_Click;
            btnRedMarker.Click += btnRedMarker_Click;
            btnOrangeMarker.Click += btnOrangeMarker_Click;


            status.AddObserver(text =>
            {
                this.ChangeStatus(text);
            });

            imageBrowser.Images.OnChange(images =>
            {
                this.BrowseFiles(images);
            });

            imagesView.AfterSelect += ImagesListView_SelectedIndexChanged;

            imageBrowser.SelectedImage.OnChange(x =>
            {
                spermogramaViewer.View(x);
            });

            spermogramaViewer.CurrentSpermogram.OnChange(spermograma =>
            {
                spermograma.DisplayImage.OnChange(image =>
                {
                    this.UpdateImage(image);
                });
            });

            spermogramaViewer.CurrentSpermogram.OnChange(spermograma =>
            {
                spermograma.Spermatosoids.OnChange((x) =>
                {
                    if (x != null)
                    {
                        this.lblRed.InvokeAsync(lbl => { lbl.Text = x.Count(xx => xx.SpermType == SpermType.Red).ToString(); });
                        this.lblGreen.InvokeAsync(lbl => { lbl.Text = x.Count(xx => xx.SpermType == SpermType.Green).ToString(); });
                        this.lblOrange.InvokeAsync(lbl => { lbl.Text = x.Count(xx => xx.SpermType == SpermType.Orange).ToString(); });
                    }
                });
            });

            pictureBox.Click += pictureBox_Click;
            // imageBrowser.Scan(@"D:\SampleImages");
            this.KeyPreview = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.D1: btnGreenMarker.PerformClick(); return true;
                case Keys.Control | Keys.D2: btnRedMarker.PerformClick(); return true;
                case Keys.Control | Keys.D3: btnOrangeMarker.PerformClick(); return true;
                default: return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void ImagesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imagesView.SelectedNode.ToolTipText) == false)
            {
                imageBrowser.Select(imagesView.SelectedNode.ToolTipText.ToString());
                labelCurrentImage.Text = imagesView.SelectedNode.ToolTipText.ToString();
            }
        }

        private void browseDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                DisableUI();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    browseDirectoryLabel.Text = folderBrowserDialog.SelectedPath;
                    imageBrowser.Scan(folderBrowserDialog.SelectedPath).ContinueWith((c) => EnableUI());
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
            imagesView.InvokeAsync(view =>
            {
                imagesView.Nodes.Clear();
                var discoverer = new DirecotryDiscoverer(images);
                discoverer.CompressRoots();
                imagesView.Nodes.AddRange(discoverer.Roots.OrderBy(x => x.DirectoryInfo.Name).Select(x => x.ToTreeViewNode()).ToArray());
            });
        }

        private void btnGreenMarker_Click(object sender, EventArgs e)
        {
            currentMarker = SpermType.Green;
        }

        private void btnRedMarker_Click(object sender, EventArgs e)
        {
            currentMarker = SpermType.Red;
        }

        private void btnOrangeMarker_Click(object sender, EventArgs e)
        {
            currentMarker = SpermType.Orange;
        }

        PropertyInfo imageRectangleProperty = typeof(PictureBox).GetProperty("ImageRectangle", BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance);

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Rectangle rectangle = (Rectangle)imageRectangleProperty.GetValue(pictureBox, null);
                if (rectangle.Contains(me.Location))
                {
                    var point = TranslateCoordinatesFromPictureBox(me.Location);
                    if (me.Button == MouseButtons.Right)
                        spermogramaViewer.CurrentSpermogram.State.UnMark(new Models.Point(point.X, point.Y));
                    if (me.Button == MouseButtons.Left && currentMarker != SpermType.Unknown)
                        spermogramaViewer.CurrentSpermogram.State.Mark(new Models.Point(point.X, point.Y), currentMarker);
                }
            }
        }

        private System.Drawing.Point TranslateCoordinatesFromPictureBox(System.Drawing.Point location)
        {
            decimal imgWidth = pictureBox.Image.Width;
            decimal imgHeight = pictureBox.Image.Height;
            decimal boxWidth = pictureBox.Size.Width;
            decimal boxHeight = pictureBox.Size.Height;

            //This variable will hold the result
            decimal X = location.X;
            decimal Y = location.Y;
            //Comparing the aspect ratio of both the control and the image itself.
            if (imgWidth / imgHeight > boxWidth / boxHeight)
            {
                //If true, that means that the image is stretched through the width of the control.
                //'In other words: the image is limited by the width.

                //The scale of the image in the Picture Box.
                decimal scale = boxWidth / imgWidth;

                //Since the image is in the middle, this code is used to determinate the empty space in the height
                //'by getting the difference between the box height and the image actual displayed height and dividing it by 2.
                decimal blankPart = (boxHeight - scale * imgHeight) / 2;

                Y -= blankPart;

                //Scaling the results.
                X /= scale;
                Y /= scale;
            }
            else
            {
                //If true, that means that the image is stretched through the height of the control.
                //'In other words: the image is limited by the height.

                //The scale of the image in the Picture Box.
                decimal scale = boxHeight / imgHeight;

                //Since the image is in the middle, this code is used to determinate the empty space in the width
                //'by getting the difference between the box width and the image actual displayed width and dividing it by 2.
                decimal blankPart = (boxWidth - scale * imgWidth) / 2;
                X -= blankPart;

                //Scaling the results.
                X /= scale;
                Y /= scale;
            }
            return new System.Drawing.Point((int)X, (int)Y);
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            spermogramaViewer.CurrentSpermogram.State.Discover();
        }
    }
}
