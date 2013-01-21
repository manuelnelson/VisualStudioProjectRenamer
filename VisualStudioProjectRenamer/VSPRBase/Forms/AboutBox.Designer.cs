using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace VSPRBase.Forms
{
    internal sealed partial class AboutBox
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
            this.lblProductName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCompanyName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCopyright = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblProductVersion = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.linkLabel = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonButtonOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.CausesValidation = false;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblProductName.Location = new System.Drawing.Point(12, 25);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(106, 20);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Values.Image = global::VSPRBase.Properties.Resources.product1;
            this.lblProductName.Values.Text = "Product Name";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.CausesValidation = false;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblCompanyName.Location = new System.Drawing.Point(12, 77);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(116, 20);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Values.Image = global::VSPRBase.Properties.Resources.company;
            this.lblCompanyName.Values.Text = "Company Name";
            // 
            // lblCopyright
            // 
            this.lblCopyright.CausesValidation = false;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblCopyright.Location = new System.Drawing.Point(12, 103);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(288, 20);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Values.Image = global::VSPRBase.Properties.Resources.copyright;
            this.lblCopyright.Values.Text = "Copyright © 2011. Kosmal Softwareentwicklung";
            // 
            // lblProductVersion
            // 
            this.lblProductVersion.CausesValidation = false;
            this.lblProductVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblProductVersion.Location = new System.Drawing.Point(12, 51);
            this.lblProductVersion.Name = "lblProductVersion";
            this.lblProductVersion.Size = new System.Drawing.Size(114, 20);
            this.lblProductVersion.TabIndex = 5;
            this.lblProductVersion.Values.Image = global::VSPRBase.Properties.Resources.version;
            this.lblProductVersion.Values.Text = "Product Version";
            // 
            // linkLabel
            // 
            this.linkLabel.CausesValidation = false;
            this.linkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.linkLabel.LinkBehavior = ComponentFactory.Krypton.Toolkit.KryptonLinkBehavior.HoverUnderline;
            this.linkLabel.Location = new System.Drawing.Point(12, 158);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.OverrideFocus.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.linkLabel.OverrideNotVisited.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.linkLabel.OverridePressed.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.linkLabel.OverrideVisited.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.linkLabel.Size = new System.Drawing.Size(214, 20);
            this.linkLabel.TabIndex = 8;
            this.linkLabel.Values.Image = global::VSPRBase.Properties.Resources.link;
            this.linkLabel.Values.Text = "http://www.normankosmal.com";
            this.linkLabel.LinkClicked += new System.EventHandler(this.LinkLabelLinkClicked);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButtonOk);
            this.kryptonPanel1.Controls.Add(this.linkLabel);
            this.kryptonPanel1.Controls.Add(this.lblCopyright);
            this.kryptonPanel1.Controls.Add(this.lblCompanyName);
            this.kryptonPanel1.Controls.Add(this.lblProductName);
            this.kryptonPanel1.Controls.Add(this.lblProductVersion);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(371, 224);
            this.kryptonPanel1.TabIndex = 9;
            // 
            // kryptonButtonOk
            // 
            this.kryptonButtonOk.Location = new System.Drawing.Point(269, 187);
            this.kryptonButtonOk.Name = "kryptonButtonOk";
            this.kryptonButtonOk.Size = new System.Drawing.Size(90, 25);
            this.kryptonButtonOk.TabIndex = 10;
            this.kryptonButtonOk.Values.Text = "OK";
            this.kryptonButtonOk.Click += new System.EventHandler(this.KryptonButtonOkClick);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 224);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonLabel lblProductName;
        private KryptonLabel lblCompanyName;
        private KryptonLabel lblCopyright;
        private KryptonLabel lblProductVersion;
        private KryptonLinkLabel linkLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButtonOk;

    }
}