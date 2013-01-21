using ComponentFactory.Krypton.Toolkit;

namespace VSPRBase.Forms
{
    internal sealed partial class ConfirmationDialog
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
            this.confirmationMessageRichTextbox = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.panel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cancelButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.confirmButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // confirmationMessageRichTextbox
            // 
            this.confirmationMessageRichTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmationMessageRichTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.confirmationMessageRichTextbox.Location = new System.Drawing.Point(3, 12);
            this.confirmationMessageRichTextbox.Name = "confirmationMessageRichTextbox";
            this.confirmationMessageRichTextbox.Size = new System.Drawing.Size(417, 168);
            this.confirmationMessageRichTextbox.TabIndex = 0;
            this.confirmationMessageRichTextbox.Text = "";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.confirmButton);
            this.panel.Controls.Add(this.confirmationMessageRichTextbox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(423, 217);
            this.panel.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(330, 186);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 25);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Values.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(234, 186);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(90, 25);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Values.Text = "Confirm";
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // ConfirmationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 217);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfirmationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfirmationDialog";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonRichTextBox confirmationMessageRichTextbox;
        private KryptonPanel panel;
        private KryptonButton cancelButton;
        private KryptonButton confirmButton;
    }
}