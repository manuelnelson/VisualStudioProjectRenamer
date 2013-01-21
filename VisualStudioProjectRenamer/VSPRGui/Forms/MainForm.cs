namespace VSPRGui.Forms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using Controller;
    using VSPRBase.Common;
    using VSPRCommon;
    using VSPRCommon.Enums;
    using VSPRCommon.EventArguments;
    using VSPRInterfaces;

    public sealed partial class MainForm : KryptonForm, IMoveable, ILocalizable
    {
        private readonly MainFormController controller;
        private bool renameButtonEnabled;
        private readonly Settings settings;
        private readonly ISettingsService settingsService;
        private string solution;
        private string statusMessage;

        public MainForm()
        {
            InitializeComponent();
            controller = new MainFormController();
            LocalizationService = ServiceLocator.GetInstance<ILocalizationService>();
            settingsService = ServiceLocator.GetInstance<ISettingsService>();
            LocalizationService.LanguageChanged += LanguageChanged;
            Localize();
            ToogleControls();
            SetStatusMessage();

            settings = settingsService.LoadSettings();
            SetGlobalPaletteMode();
            SetLanguage();

            controller.UpdateOnStartup(settings);
        }

        public ILocalizationService LocalizationService { get; private set; }

        public Point MouseOffset { get; private set; }

        public delegate void InvokeDelegate();

        public void Header_MouseEnter(object sender, EventArgs e)
        {
            if(!Cursor.Equals(Cursors.WaitCursor))
            {
                Cursor = Cursors.Hand;
            }
        }

        public void Header_MouseLeave(object sender, EventArgs e)
        {
            if(!Cursor.Equals(Cursors.WaitCursor))
            {
                Cursor = Cursors.Default;
            }
        }

        public void LanguageChanged(object sender, LanguageChangedEventArgs args)
        {
            Localize();
        }

        public void Localize()
        {
            exitButton.Text = LocalizationService.GetString(LocalizationResourceNames.MainFormCloseButtonText);
            renameButton.Text = LocalizationService.GetString(LocalizationResourceNames.MainFormRenameButtonText);
            oldProjectNameLabel.Text = LocalizationService.GetString(LocalizationResourceNames.MainFormLabelOldProjectNameText);
            newProjectNameLabel.Text = LocalizationService.GetString(LocalizationResourceNames.MainFormLabelNewProjectNameText);
            isUnderVersionControlCheckbox.Text = LocalizationService.GetString(LocalizationResourceNames.MainFormCheckBoxSolutionVersionControlText);
            checkInChangesCheckbox.Text = LocalizationService.GetString(LocalizationResourceNames.MainFormCheckBoxCheckInChangesText);
            browseButton.Text = LocalizationService.GetString(LocalizationResourceNames.MainFormBrowseButtonText);
            showSettingsFormToolStripButton.ToolTipText = LocalizationService.GetString(LocalizationResourceNames.MainFormButtonShowSettingsFormToolTip);
            showAboutFormToolStripButton.ToolTipText = LocalizationService.GetString(LocalizationResourceNames.MainFormButtonShowAboutFormToolTip);
            sendToTrayToolStripButton.ToolTipText = LocalizationService.GetString(LocalizationResourceNames.MainFormButtonSendToTrayToolTip);
            updateToolStripButton.ToolTipText = LocalizationService.GetString(LocalizationResourceNames.MainFormUpdateButtonToolTipText);
            notifyIcon.BalloonTipText = LocalizationService.GetString(LocalizationResourceNames.MainFormNotifyIconBallonTipText);
            renameMainEntryFileCheckBox.Text = LocalizationService.GetString(LocalizationResourceNames.MainFormCheckboxRenameMainEntryFile);

            // TODO NKO: Localize ones this functionality is implemented.
            //adjustFolderNamesCheckBox.Text = "TODO NKO: Localize";

            statusMessage = LocalizationService.GetString(LocalizationResourceNames.MainFormStatusLabelSelectSolution);
            SetStatusMessage();
        }

        public void MoveFormOn_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(MouseOffset.X, MouseOffset.Y);

                // Move the form to the desired location
                Location = mousePos;
            }
        }

        public void RenameFinished(object sender, RenameFinishedEventArgs args)
        {
            statusMessage = BuildStatusMessage(args);
            renameButtonEnabled = args.Finished;

            if(InvokeRequired)
            {
                Invoke(new InvokeDelegate(UpdateProjects));
                Invoke(new InvokeDelegate(SetStatusMessage));
                Invoke(new InvokeDelegate(EnableRenameButton));
            }
            else
            {
                SetupBindingSource();

                statusLabel.Text = statusMessage;
                renameButton.Enabled = args.Finished;
                newProjectNameTextbox.Text = string.Empty;
            }
        }

        public void SetOffSetOn_MouseDown(object sender, MouseEventArgs e)
        {
            MouseOffset = new Point(-e.X, -e.Y);
        }

        private void BrowseButtonClick(object sender, EventArgs e)
        {
            solution = ShowFileDialog();

            try
            {
                if(!string.IsNullOrEmpty(solution) && solution.EndsWith(".sln"))
                {
                    controller.Guard.FileExists(solution);

                    solutionPathTextbox.Text = solution;

                    SetupBindingSource();

                    ShowControls();
                    statusMessage = LocalizationService.GetString(LocalizationResourceNames.MainFormStatusLabelSelectProject);
                    SetStatusMessage();
                }
                else
                {
                    string message = LocalizationService.GetString(LocalizationResourceNames.MainFormErrorNoSolutionFile);
                    controller.HandleError(message);
                }
            }
            catch(ArgumentException argumentException)
            {
                controller.HandleError(argumentException.Message);
            }
        }

        private string BuildStatusMessage(RenameFinishedEventArgs args)
        {
            // TODO NKO: Use the args.RollbackSuccessfull flag for a proper message so the user does now that a rollback failed or completed.
            return args.RenameSuccessfull ? LocalizationService.GetString(LocalizationResourceNames.MainFormStatusLabelRenamingSuccessfull) : LocalizationService.GetString(LocalizationResourceNames.MainFormStatusLabelRenamingFailed);
        }

        private void CheckboxIsUnderVersionControlCheckedChanged(object sender, EventArgs e)
        {
            if(isUnderVersionControlCheckbox.Checked)
            {
                checkInChangesCheckbox.Visible = true;
                checkInChangesCheckbox.Enabled = true;
                checkInChangesCheckbox.Checked = false;
            }
            else
            {
                checkInChangesCheckbox.Visible = false;
                checkInChangesCheckbox.Enabled = false;
                checkInChangesCheckbox.Checked = false;
            }
        }

        private void ComboboxOldProjectNamesSelectedValueChanged(object sender, EventArgs e)
        {
            // TODO NKO Comment in, when implemented in the renameservice / renamers.
            //ToogleAdjustFolderNameCheckBox();
            object value = oldProjectNamesCombobox.SelectedValue;

            if(value != null)
            {
                newProjectNameTextbox.Text = value.ToString();
            }
        }

        private DialogResult ConfirmRename(Project oldProject, Project newProject)
        {
            return controller.ConfirmRename(oldProject, newProject);
        }

        private void EnableRenameButton()
        {
            renameButton.Enabled = renameButtonEnabled;
            Cursor = Cursors.Default;
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void NotifyIconDoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Show();

            notifyIcon.Visible = false;
        }

        private void RenameButtonClick(object sender, EventArgs e)
        {
            Project newProject = new Project { ProjectName = this.newProjectNameTextbox.Text };
            Project oldProject = (Project)oldProjectNamesCombobox.SelectedItem;

            bool isValid = controller.ValidateParameter(oldProject, newProject);

            if(isValid)
            {
                DialogResult dialogResult = ConfirmRename(oldProject, newProject);

                if(dialogResult.Equals(DialogResult.OK))
                {
                    // Disable the rename button to prevent a double click on it while renaming is in progress
                    renameButton.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    statusLabel.Text = LocalizationService.GetString(LocalizationResourceNames.MainFormStatusLabelRenamingProject);

                    try
                    {
                        bool commitChanges = checkInChangesCheckbox.Checked;
                        bool isUnderVersionControl = isUnderVersionControlCheckbox.Checked;
                        bool adjustFolderNameProjectNameMissmatch = adjustFolderNamesCheckBox.Checked;
                        bool renameMainEntryFile = renameMainEntryFileCheckBox.Checked;

                        controller.Rename(solution, oldProject, newProject, isUnderVersionControl, commitChanges ,adjustFolderNameProjectNameMissmatch, renameMainEntryFile, this);
                    }
                    catch(Exception exception)
                    {
                        controller.HandleError(exception.Message);
                    }
                }
            }
            else
            {
                string message = LocalizationService.GetString(LocalizationResourceNames.MainFormErrorMessageNewProjectNameEqualsOldProjectNameOrIsEmpty);
                controller.HandleError(message);
            }
        }

        private void SetGlobalPaletteMode()
        {
            kryptonManager.GlobalPaletteMode = settings.Layout;
        }

        private void SetLanguage()
        {
            LocalizationService.SetCulture(settings.SelectedLanguage);
        }

        private void SetStatusMessage()
        {
            statusLabel.Text = statusMessage;
        }

        private void SetupBindingSource()
        {
            BindingSource bindingSource = new BindingSource { DataSource = controller.GetSolutionProjects(solution) };
            oldProjectNamesCombobox.DataSource = bindingSource;
            oldProjectNamesCombobox.DisplayMember = "ProjectName";
            oldProjectNamesCombobox.ValueMember = "ProjectName";
        }

        private void ShowControls()
        {
            oldProjectNameLabel.Visible = true;
            oldProjectNamesCombobox.Visible = true;
            newProjectNameLabel.Visible = true;
            newProjectNameTextbox.Visible = true;
            isUnderVersionControlCheckbox.Visible = true;
            renameButton.Visible = true;
            
            // TODO NKO Comment in, when implemented in the renameservice / renamers.
            //ToogleAdjustFolderNameCheckBox();

            var selectedProject = (Project)oldProjectNamesCombobox.SelectedItem;
            if(selectedProject.ProjectType.Equals(ProjectType.Cplusplus))
            {
                renameMainEntryFileCheckBox.Visible = true;
            }
            else
            {
                renameMainEntryFileCheckBox.Visible = false;
            }
        }

        private string ShowFileDialog()
        {
            openFileDialog.Filter = string.Format("sln files (*.sln)|*.sln|All files (*.*)|*.*");
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();

            return openFileDialog.FileName;
        }

        private void ToogleAdjustFolderNameCheckBox()
        {
            // Show the Adjust foldernames checkbox if the foldername and the project do not match
            var selectedProject = (Project)oldProjectNamesCombobox.SelectedItem;
            if(!selectedProject.FolderNameEqualsProjectName())
            {
                adjustFolderNamesCheckBox.Visible = true;
            }
            else
            {
                adjustFolderNamesCheckBox.Visible = false;
                adjustFolderNamesCheckBox.Checked = false;
            }
        }

        private void ToogleControls()
        {
            solutionPathTextbox.Enabled = false;
            oldProjectNameLabel.Visible = false;
            oldProjectNamesCombobox.Visible = false;
            newProjectNameLabel.Visible = false;
            checkInChangesCheckbox.Visible = false;
            newProjectNameTextbox.Visible = false;
            renameMainEntryFileCheckBox.Visible = false;
            isUnderVersionControlCheckbox.Visible = false;
            renameButton.Visible = false;
            adjustFolderNamesCheckBox.Visible = false;
        }

        private void ToolStripButtonSendToTrayClick(object sender, EventArgs e)
        {
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(200);
            Hide();
        }

        private void ToolStripButtonShowAboutFormClick(object sender, EventArgs e)
        {
            controller.ShowAboutBox();
        }

        private void ToolStripButtonShowSettingsClick(object sender, EventArgs e)
        {
            controller.ShowSettingsForm();
        }

        private void ToolStripButtonUpdateClick(object sender, EventArgs e)
        {
            controller.Update();
        }

        private void UpdateProjects()
        {
            SetupBindingSource();

            // Update the new project name textfield with the selected project name.
            object value = oldProjectNamesCombobox.SelectedValue;

            if(value != null)
            {
                newProjectNameTextbox.Text = value.ToString();
            }
        }
    }
}