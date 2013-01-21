namespace VSPRExtension
{
	/// <summary>
	/// 
	/// </summary>
	partial class RenamerView
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
			if ( disposing && (components != null) )
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
			this.TxtBoxNewProjectName = new System.Windows.Forms.TextBox();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnOK = new System.Windows.Forms.Button();
			this.LblNewProjectName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// TxtBoxNewProjectName
			// 
			this.TxtBoxNewProjectName.Location = new System.Drawing.Point(6, 35);
			this.TxtBoxNewProjectName.Name = "TxtBoxNewProjectName";
			this.TxtBoxNewProjectName.Size = new System.Drawing.Size(274, 20);
			this.TxtBoxNewProjectName.TabIndex = 0;
			// 
			// BtnCancel
			// 
			this.BtnCancel.Location = new System.Drawing.Point(205, 70);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 1;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnOK
			// 
			this.BtnOK.Location = new System.Drawing.Point(124, 70);
			this.BtnOK.Name = "BtnOK";
			this.BtnOK.Size = new System.Drawing.Size(75, 23);
			this.BtnOK.TabIndex = 2;
			this.BtnOK.Text = "OK";
			this.BtnOK.UseVisualStyleBackColor = true;
			this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
			// 
			// LblNewProjectName
			// 
			this.LblNewProjectName.AutoSize = true;
			this.LblNewProjectName.Location = new System.Drawing.Point(6, 13);
			this.LblNewProjectName.Name = "LblNewProjectName";
			this.LblNewProjectName.Size = new System.Drawing.Size(140, 13);
			this.LblNewProjectName.TabIndex = 3;
			this.LblNewProjectName.Text = "Enter the new project name:";
			// 
			// RenamerView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 103);
			this.Controls.Add(this.LblNewProjectName);
			this.Controls.Add(this.BtnOK);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.TxtBoxNewProjectName);
			this.Name = "RenamerView";
			this.Text = "RenamerView";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TxtBoxNewProjectName;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Button BtnOK;
		private System.Windows.Forms.Label LblNewProjectName;
	}
}