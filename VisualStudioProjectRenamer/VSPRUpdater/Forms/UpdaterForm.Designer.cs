namespace VSPRUpdater.Forms
{
    partial class UpdaterForm
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
            this.installButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cancelButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.newVersionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.infoTextLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.releaseNotesLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Browser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.installButton);
            this.kryptonPanel.Controls.Add(this.cancelButton);
            this.kryptonPanel.Controls.Add(this.newVersionLabel);
            this.kryptonPanel.Controls.Add(this.infoTextLabel);
            this.kryptonPanel.Controls.Add(this.releaseNotesLabel);
            this.kryptonPanel.Controls.Add(this.Browser);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(576, 369);
            this.kryptonPanel.TabIndex = 0;
            // 
            // installButton
            // 
            this.installButton.Location = new System.Drawing.Point(473, 332);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(90, 25);
            this.installButton.TabIndex = 11;
            this.installButton.Values.Text = "Install";
            this.installButton.Click += new System.EventHandler(this.UpdateButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(377, 332);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 25);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Values.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // newVersionLabel
            // 
            this.newVersionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.newVersionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.newVersionLabel.Location = new System.Drawing.Point(12, 12);
            this.newVersionLabel.Name = "newVersionLabel";
            this.newVersionLabel.Size = new System.Drawing.Size(192, 20);
            this.newVersionLabel.TabIndex = 9;
            this.newVersionLabel.Values.Text = "A new version of APP is available!";
            // 
            // infoTextLabel
            // 
            this.infoTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.infoTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoTextLabel.Location = new System.Drawing.Point(12, 38);
            this.infoTextLabel.Name = "infoTextLabel";
            this.infoTextLabel.Size = new System.Drawing.Size(461, 20);
            this.infoTextLabel.TabIndex = 8;
            this.infoTextLabel.Values.Text = "APP is now available (you have OLDVERSION). Would you like to download it now?";
            // 
            // releaseNotesLabel
            // 
            this.releaseNotesLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.releaseNotesLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.releaseNotesLabel.Location = new System.Drawing.Point(12, 76);
            this.releaseNotesLabel.Name = "releaseNotesLabel";
            this.releaseNotesLabel.Size = new System.Drawing.Size(88, 20);
            this.releaseNotesLabel.TabIndex = 7;
            this.releaseNotesLabel.Values.Text = "Release notes:";
            // 
            // Browser
            // 
            this.Browser.AllowNavigation = false;
            this.Browser.IsWebBrowserContextMenuEnabled = false;
            this.Browser.Location = new System.Drawing.Point(12, 102);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 28);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(551, 216);
            this.Browser.TabIndex = 1;
            // 
            // UpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 369);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdaterForm";
            this.Text = "Update available";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.WebBrowser Browser;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel newVersionLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel infoTextLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel releaseNotesLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton installButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton cancelButton;
    }
}

