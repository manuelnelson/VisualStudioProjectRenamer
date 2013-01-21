namespace VSPRUpdater.Common
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using VSPRCommon;
    using VSPRInterfaces;

    internal class Installer : IInstaller
    {
        private readonly string batchFile;
        private readonly string commandLine;
        private readonly string currentDirectory;
        private readonly ILocalizationService localizationService;
        private string batchCommand;
        private IUpdater updater;

        public Installer(ILocalizationService localizationService)
        {
            this.localizationService = localizationService;

            commandLine = Environment.CommandLine;
            currentDirectory = Environment.CurrentDirectory;
            batchFile = Environment.ExpandEnvironmentVariables("%temp%\\" + Guid.NewGuid() + ".cmd");
        }

        public void Install(string fileName, IUpdater updaterInstance)
        {
            updater = updaterInstance;

            string extension = Path.GetExtension(fileName);
            if(extension != null && extension.ToLower().Equals(".msi"))
            {
                batchCommand = "msiexec /i \"" + fileName + "\"";
            }
            else
            {
                string message = string.Format(localizationService.GetString(LocalizationResourceNames.InstallerExtensionNotSupportedMessage), extension, fileName);
                string caption = localizationService.GetString(LocalizationResourceNames.InstallerMessageBoxCaption);
                
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            WriteBatchFile();
            ExecuteBatchFile();
        }

        private void ExecuteBatchFile()
        {
            string diagMessage = string.Format(localizationService.GetString(LocalizationResourceNames.InstallerExecutingBatchFileMessage), batchFile);
            updater.ReportDiagnosticMessage(diagMessage);

            Process process = new Process { StartInfo = { FileName = batchFile, WindowStyle = ProcessWindowStyle.Hidden } };
            process.Start();

            Environment.Exit(0);
        }

        private void WriteBatchFile()
        {
            string diagMessage = string.Format(localizationService.GetString(LocalizationResourceNames.InstallerGeneratingBatchFileMessage), Path.GetFullPath(batchFile));
            updater.ReportDiagnosticMessage(diagMessage);

            using(StreamWriter streamWriter = new StreamWriter(batchFile))
            {
                streamWriter.WriteLine(batchCommand);
                streamWriter.WriteLine("cd " + currentDirectory);
                streamWriter.WriteLine(commandLine);
            }
        }
    }
}