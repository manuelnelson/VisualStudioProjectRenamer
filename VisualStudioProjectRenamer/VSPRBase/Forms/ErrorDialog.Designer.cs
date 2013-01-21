using ComponentFactory.Krypton.Toolkit;

namespace VSPRBase.Forms
{
    internal sealed partial class ErrorDialog
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
            this.errorMessageRichtTextBox = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.errorMessageInfoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblStatus = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.closeButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.copyToClipBoardButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorMessageRichtTextBox
            // 
            this.errorMessageRichtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorMessageRichtTextBox.Location = new System.Drawing.Point(3, 38);
            this.errorMessageRichtTextBox.Name = "errorMessageRichtTextBox";
            this.errorMessageRichtTextBox.ReadOnly = true;
            this.errorMessageRichtTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.errorMessageRichtTextBox.Size = new System.Drawing.Size(566, 171);
            this.errorMessageRichtTextBox.TabIndex = 0;
            this.errorMessageRichtTextBox.Text = "";
            // 
            // errorMessageInfoLabel
            // 
            this.errorMessageInfoLabel.Location = new System.Drawing.Point(3, 12);
            this.errorMessageInfoLabel.Name = "errorMessageInfoLabel";
            this.errorMessageInfoLabel.Size = new System.Drawing.Size(305, 20);
            this.errorMessageInfoLabel.TabIndex = 3;
            this.errorMessageInfoLabel.Values.Text = "An error occured while renaming, check details below:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(3, 220);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(6, 2);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Values.Text = "";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.closeButton);
            this.panel.Controls.Add(this.copyToClipBoardButton);
            this.panel.Controls.Add(this.errorMessageRichtTextBox);
            this.panel.Controls.Add(this.lblStatus);
            this.panel.Controls.Add(this.errorMessageInfoLabel);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(572, 247);
            this.panel.TabIndex = 5;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(479, 215);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(90, 25);
            this.closeButton.TabIndex = 6;
            this.closeButton.Values.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // copyToClipBoardButton
            // 
            this.copyToClipBoardButton.Location = new System.Drawing.Point(383, 215);
            this.copyToClipBoardButton.Name = "copyToClipBoardButton";
            this.copyToClipBoardButton.Size = new System.Drawing.Size(90, 25);
            this.copyToClipBoardButton.TabIndex = 5;
            this.copyToClipBoardButton.Values.Text = "Copy";
            this.copyToClipBoardButton.Click += new System.EventHandler(this.CopyToClipBoardButtonClick);
            this.copyToClipBoardButton.MouseLeave += new System.EventHandler(this.CopyToClipBoardButtonMouseLeave);
            this.copyToClipBoardButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CopyToClipBoardButtonMouseMove);
            // 
            // ErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 247);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ErrorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ErrorDialog";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonRichTextBox errorMessageRichtTextBox;
        private KryptonLabel errorMessageInfoLabel;
        private KryptonLabel lblStatus;
        private KryptonPanel panel;
        private KryptonButton copyToClipBoardButton;
        private KryptonButton closeButton;
    }
}