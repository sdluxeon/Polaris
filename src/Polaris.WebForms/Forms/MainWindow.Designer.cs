namespace Polaris.WebForms.Forms
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.browseDirectory = new System.Windows.Forms.Button();
            this.browseDirectoryLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.imagesListView = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCurrentImage = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDiscover = new System.Windows.Forms.Button();
            this.btnOrangeMarker = new System.Windows.Forms.RadioButton();
            this.btnRedMarker = new System.Windows.Forms.RadioButton();
            this.btnGreenMarker = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblOrange = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.statusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 927);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1533, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // statusBarLabel
            // 
            this.statusBarLabel.Name = "statusBarLabel";
            this.statusBarLabel.Size = new System.Drawing.Size(39, 17);
            this.statusBarLabel.Text = "Ready";
            // 
            // browseDirectory
            // 
            this.browseDirectory.Location = new System.Drawing.Point(12, 12);
            this.browseDirectory.Name = "browseDirectory";
            this.browseDirectory.Size = new System.Drawing.Size(75, 23);
            this.browseDirectory.TabIndex = 3;
            this.browseDirectory.Text = "Browse";
            this.browseDirectory.UseVisualStyleBackColor = true;
            this.browseDirectory.Click += new System.EventHandler(this.browseDirectory_Click);
            // 
            // browseDirectoryLabel
            // 
            this.browseDirectoryLabel.AutoSize = true;
            this.browseDirectoryLabel.Location = new System.Drawing.Point(93, 17);
            this.browseDirectoryLabel.Name = "browseDirectoryLabel";
            this.browseDirectoryLabel.Size = new System.Drawing.Size(127, 13);
            this.browseDirectoryLabel.TabIndex = 4;
            this.browseDirectoryLabel.Text = "Please Select A Directory";
            // 
            // imagesListView
            // 
            this.imagesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagesListView.FormattingEnabled = true;
            this.imagesListView.Location = new System.Drawing.Point(12, 39);
            this.imagesListView.Name = "imagesListView";
            this.imagesListView.Size = new System.Drawing.Size(367, 875);
            this.imagesListView.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.labelCurrentImage);
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(388, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 924);
            this.panel1.TabIndex = 0;
            // 
            // labelCurrentImage
            // 
            this.labelCurrentImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentImage.Location = new System.Drawing.Point(1, 14);
            this.labelCurrentImage.Name = "labelCurrentImage";
            this.labelCurrentImage.ReadOnly = true;
            this.labelCurrentImage.Size = new System.Drawing.Size(822, 20);
            this.labelCurrentImage.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 39);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(826, 872);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.imagesListView);
            this.panel2.Controls.Add(this.browseDirectory);
            this.panel2.Controls.Add(this.browseDirectoryLabel);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 924);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDiscover);
            this.panel3.Controls.Add(this.btnOrangeMarker);
            this.panel3.Controls.Add(this.btnRedMarker);
            this.panel3.Controls.Add(this.btnGreenMarker);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblRed);
            this.panel3.Controls.Add(this.lblOrange);
            this.panel3.Controls.Add(this.lblGreen);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1220, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 927);
            this.panel3.TabIndex = 7;
            // 
            // btnDiscover
            // 
            this.btnDiscover.Location = new System.Drawing.Point(226, 12);
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Size = new System.Drawing.Size(75, 23);
            this.btnDiscover.TabIndex = 11;
            this.btnDiscover.Text = "Discover";
            this.btnDiscover.UseVisualStyleBackColor = true;
            this.btnDiscover.Click += new System.EventHandler(this.btnDiscover_Click);
            // 
            // btnOrangeMarker
            // 
            this.btnOrangeMarker.AutoSize = true;
            this.btnOrangeMarker.Location = new System.Drawing.Point(6, 136);
            this.btnOrangeMarker.Name = "btnOrangeMarker";
            this.btnOrangeMarker.Size = new System.Drawing.Size(60, 17);
            this.btnOrangeMarker.TabIndex = 10;
            this.btnOrangeMarker.Text = "Orange";
            this.btnOrangeMarker.UseVisualStyleBackColor = true;
            // 
            // btnRedMarker
            // 
            this.btnRedMarker.AutoSize = true;
            this.btnRedMarker.Location = new System.Drawing.Point(6, 113);
            this.btnRedMarker.Name = "btnRedMarker";
            this.btnRedMarker.Size = new System.Drawing.Size(45, 17);
            this.btnRedMarker.TabIndex = 9;
            this.btnRedMarker.Text = "Red";
            this.btnRedMarker.UseVisualStyleBackColor = true;
            // 
            // btnGreenMarker
            // 
            this.btnGreenMarker.AutoSize = true;
            this.btnGreenMarker.Checked = true;
            this.btnGreenMarker.Location = new System.Drawing.Point(6, 90);
            this.btnGreenMarker.Name = "btnGreenMarker";
            this.btnGreenMarker.Size = new System.Drawing.Size(54, 17);
            this.btnGreenMarker.TabIndex = 8;
            this.btnGreenMarker.TabStop = true;
            this.btnGreenMarker.Text = "Green";
            this.btnGreenMarker.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Markers";
            // 
            // lblRed
            // 
            this.lblRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(57, 903);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(13, 13);
            this.lblRed.TabIndex = 5;
            this.lblRed.Text = "0";
            // 
            // lblOrange
            // 
            this.lblOrange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrange.AutoSize = true;
            this.lblOrange.Location = new System.Drawing.Point(57, 873);
            this.lblOrange.Name = "lblOrange";
            this.lblOrange.Size = new System.Drawing.Size(13, 13);
            this.lblOrange.TabIndex = 4;
            this.lblOrange.Text = "0";
            // 
            // lblGreen
            // 
            this.lblGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGreen.AutoSize = true;
            this.lblGreen.Location = new System.Drawing.Point(57, 843);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(13, 13);
            this.lblGreen.TabIndex = 3;
            this.lblGreen.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 873);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Orange: ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 843);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Green: ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 903);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red: ";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 949);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel;
        private System.Windows.Forms.Button browseDirectory;
        private System.Windows.Forms.Label browseDirectoryLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListBox imagesListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrange;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.RadioButton btnOrangeMarker;
        private System.Windows.Forms.RadioButton btnRedMarker;
        private System.Windows.Forms.RadioButton btnGreenMarker;
        private System.Windows.Forms.Button btnDiscover;
        private System.Windows.Forms.TextBox labelCurrentImage;
    }
}