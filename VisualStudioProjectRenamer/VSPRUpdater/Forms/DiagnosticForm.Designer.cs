using ComponentFactory.Krypton.Toolkit;

namespace VSPRUpdater.Forms
{
    partial class DiagnosticForm
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
            this.listBox = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.panel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.closeButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlGroupBox;
            this.listBox.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlGroupBox;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(592, 237);
            this.listBox.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.closeButton);
            this.panel.Controls.Add(this.listBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(616, 293);
            this.panel.TabIndex = 2;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(514, 255);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(90, 25);
            this.closeButton.TabIndex = 3;
            this.closeButton.Values.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // DiagnosticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 293);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DiagnosticForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Software Update - Debug Window";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonListBox listBox;
        private KryptonPanel panel;
        private KryptonButton closeButton;
    }
}