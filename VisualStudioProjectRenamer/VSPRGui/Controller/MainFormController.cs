namespace VSPRGui.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Schedulers;
    using System.Windows.Forms;
    using Forms;
    using VSPRBase.Common;
    using VSPRCommon;
    using VSPRInterfaces;

    internal sealed class MainFormController
    {
        private static readonly StaTaskScheduler MyStaTaskScheduler = new StaTaskScheduler(4);
        private readonly IAboutBoxService aboutboxService;
        private readonly IConfirmationDialogService confirmationDialogService;
        private readonly IErrorDialogService errorDialogService;
        private readonly IProjectService projectService;
        private readonly IRenameService renamerService;
        private readonly ISettingsFormService settingsFormService;
        private readonly IUpdateService updateService;

        public MainFormController()
        {
            Guard = ServiceLocator.GetInstance<IGuard>();
            projectService = ServiceLocator.GetInstance<IProjectService>();
            aboutboxService = ServiceLocator.GetInstance<IAboutBoxService>();
            settingsFormService = ServiceLocator.GetInstance<ISettingsFormService>();
            confirmationDialogService = ServiceLocator.GetInstance<IConfirmationDialogService>();
            renamerService = ServiceLocator.GetInstance<IRenameService>();
            errorDialogService = ServiceLocator.GetInstance<IErrorDialogService>();
            updateService = ServiceLocator.GetInstance<IUpdateService>();
        }

        public IGuard Guard { get; private set; }

        public DialogResult ConfirmRename(Project oldProject, Project newProject)
        {
            return confirmationDialogService.ShowConfirmationDialog(oldProject, newProject);
        }

        public void HandleError(string message)
        {
            errorDialogService.HandleError(message);
        }

        public void ShowAboutBox()
        {
            aboutboxService.ShowAboutBox();
        }

        public void ShowSettingsForm()
        {
            settingsFormService.ShowSettingsForm();
        }

        public void Update()
        {
            updateService.CheckForUpdate();
        }

        internal IList<Project> GetSolutionProjects(string solutionpath)
        {
            IList<Project> projects = projectService.GetProjects(solutionpath);

            return projects;
        }

        internal void Rename(string solution, Project oldProject, Project newProject, bool isUnderVersionControl, bool commitChanges, bool adjustFolderNameProjectNameMissmatch, bool renameMainEntryFile ,MainForm form = null)
        {
            RenameContext context = new RenameContext
                {
                    Solution = solution,
                    OldProject = oldProject,
                    NewProject = newProject,
                    IsUnderVersionControl = isUnderVersionControl,
                    CommitChanges = commitChanges,
                    AdjustFolderNameProjectNameMissmatch = adjustFolderNameProjectNameMissmatch,
                    RenameMainEntryFile = renameMainEntryFile
                };


            if(form != null)
            {
                renamerService.RenameFinished += form.RenameFinished;
            }

            Task.Factory.StartNew(() => renamerService.Rename(context), CancellationToken.None, TaskCreationOptions.None, MyStaTaskScheduler);
        }

        internal bool ValidateParameter(Project oldProject, Project newProject)
        {
            bool valid = true;

            try
            {
                Guard.IsNotNullOrEmpty(oldProject.ProjectName);
                Guard.IsNotNullOrEmpty(newProject.ProjectName);

                if(oldProject.ProjectName.Equals(newProject.ProjectName))
                {
                    valid = false;
                }
                // Note NKO: Add more validation here if needed.
            }
            catch(ArgumentException)
            {
                valid = false;
            }

            return valid;
        }

        public void UpdateOnStartup(Settings settings)
        {
            if(settings.CheckForUpdateOnStartup)
            {
                updateService.CheckForUpdate();
            }
        }
    }
}