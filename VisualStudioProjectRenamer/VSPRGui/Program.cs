namespace VSPRGui
{
    using System;
    using System.Windows.Forms;
    using Forms;
    using VSPRBase.Common;

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Initialize Dependency Container in the shared VSPRBase.dll by 
                // calling the initialize method of the service locator
                // TODO NKO This should be done inside the base dll..inside the entry point
                // which is the rename service..
                ServiceLocator.Initialize();
                Application.Run(new MainForm());
            }
            catch (Exception exception)
            {
                string message = string.Format("Exception: {0}", exception.Message);
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}