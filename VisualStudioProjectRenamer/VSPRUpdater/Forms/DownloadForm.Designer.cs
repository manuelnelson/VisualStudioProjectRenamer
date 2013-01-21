namespace VSPRUpdater.Forms
{
    using ComponentFactory.Krypton.Toolkit;

    partial class DownloadForm
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
            if(disposing && (components != null))
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
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.installAndRelaunchButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.headerLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.installAndRelaunchButton);
            this.kryptonPanel.Controls.Add(this.headerLabel);
            this.kryptonPanel.Controls.Add(this.downloadProgressBar);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(315, 115);
            this.kryptonPanel.TabIndex = 0;
            // 
            // installAndRelaunchButton
            // 
            this.installAndRelaunchButton.Location = new System.Drawing.Point(213, 78);
            this.installAndRelaunchButton.Name = "installAndRelaunchButton";
            this.installAndRelaunchButton.Size = new System.Drawing.Size(90, 25);
            this.installAndRelaunchButton.TabIndex = 16;
            this.installAndRelaunchButton.Values.Text = "Install";
            this.installAndRelaunchButton.Click += new System.EventHandler(this.InstallAndRelaunchButtonClick);
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.headerLabel.Location = new System.Drawing.Point(12, 12);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(109, 20);
            this.headerLabel.TabIndex = 12;
            this.headerLabel.Values.Text = "Downloading APP";
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadProgressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.downloadProgressBar.Location = new System.Drawing.Point(12, 38);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(291, 23);
            this.downloadProgressBar.TabIndex = 13;
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 115);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DownloadForm";
            this.Text = "Downloading update";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel;
        private KryptonLabel headerLabel;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private KryptonButton installAndRelaunchButton;
    }
}

