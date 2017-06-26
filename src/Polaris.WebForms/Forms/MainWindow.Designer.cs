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
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 710);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1752, 22);
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
            this.browseDirectoryLabel.Location = new System.Drawing.Point(12, 590);
            this.browseDirectoryLabel.Name = "browseDirectoryLabel";
            this.browseDirectoryLabel.Size = new System.Drawing.Size(127, 13);
            this.browseDirectoryLabel.TabIndex = 4;
            this.browseDirectoryLabel.Text = "Please Select A Directory";
            // 
            // imagesListView
            // 
            this.imagesListView.FormattingEnabled = true;
            this.imagesListView.Location = new System.Drawing.Point(12, 41);
            this.imagesListView.Name = "imagesListView";
            this.imagesListView.Size = new System.Drawing.Size(314, 537);
            this.imagesListView.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1752, 732);
            this.Controls.Add(this.imagesListView);
            this.Controls.Add(this.browseDirectoryLabel);
            this.Controls.Add(this.browseDirectory);
            this.Controls.Add(this.statusBar);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
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
    }
}