namespace VSPRExtension
{
	using System;
	using System.Windows.Forms;

	///<summary>
	///</summary>
	public partial class RenamerView : Form
	{
		///<summary>
		///</summary>
		public RenamerView()
		{
			InitializeComponent();
		}

		///<summary>
		///</summary>
		public string NewProjectName { get; private set; }

		private void BtnOK_Click(object sender, EventArgs e)
		{
			string newProjectName = this.TxtBoxNewProjectName.Text;
			if ( !string.IsNullOrEmpty(newProjectName) )
			{
				// TODO NKO: Strip all invalid Chars etc..
				this.NewProjectName = newProjectName;
			}

			this.DialogResult = DialogResult.OK;
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}
