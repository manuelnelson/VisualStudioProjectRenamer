namespace VSPRBase.Renamer
{
    using System.IO;
    using Common;
    using VSPRCommon;
    using VSPRCommon.Enums;
    using VSPRInterfaces;

    internal sealed class StandardRenamer : IRenamer
    {
        private readonly ICopyService copyService;

        public StandardRenamer(ICopyService copyService)
        {
            this.copyService = copyService;
        }

        public void CheckInChanges(string solutionDirectoryPath, Project oldProject, Project newProject)
        {
            // Note: An implementation is not needed here.
        }

        public void Cleanup(Project project)
        {
            string targetDirectory = string.Format("{0}{1}", project.ProjectDirectory, Constants.ProjectDirectoryBackupExtension);
            string targetFile = string.Format("{0}{1}", project.SolutionPath, Constants.SolutionBackupExtension);

            if (Directory.Exists(targetDirectory))
            {
                Directory.Delete(targetDirectory, true);
            }

            if (File.Exists(targetFile))
            {
                File.Delete(targetFile);
            }
        }

        public void RenameMainEntryFile(RenameContext context)
        {
            if (!context.RenameMainEntryFile)
            {
                return;
            }

            string oldMainEntryFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.OldProject.ProjectName, ".cpp");
            string newMainEntryFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.NewProject.ProjectName, ".cpp");

            // Only if the main entry file in c++ projects has the same name as the project itself, move it.
            if (File.Exists(oldMainEntryFile))
            {
                File.Move(oldMainEntryFile, newMainEntryFile);
            }
        }

        public void RenameProjectFile(RenameContext context)
        {
            string oldProjectFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.OldProject.ProjectName, context.OldProject.ProjectExtension);
            string newProjectFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.NewProject.ProjectName, context.NewProject.ProjectExtension);

            if (File.Exists(oldProjectFile))
            {
                File.Move(oldProjectFile, newProjectFile);
            }
        }

        public void RenameProjectFiltersFile(RenameContext context)
        {
            if (!context.OldProject.ProjectType.Equals(ProjectType.Cplusplus))
            {
                return;
            }

            string oldProjectFiltersFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.OldProject.ProjectName, ".vcxproj.filters");
            string newProjectFiltersFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.NewProject.ProjectName, ".vcxproj.filters");

            if (File.Exists(oldProjectFiltersFile))
            {
                File.Move(oldProjectFiltersFile, newProjectFiltersFile);
            }
        }

        public void RenameProjectFolder(RenameContext context)
        {
            // Since this method is called first, we do a backup here.
            CreateBackup(context.OldProject);

            Directory.Move(context.OldProject.ProjectDirectory, context.NewProject.ProjectDirectory);
        }

        public bool Rollback(string solutionDirectoryPath, RenameContext context)
        {
            // Remove the new created folder and the modified solution file.
            string newProjectDirectory = context.NewProject.ProjectDirectory;
            string modifiedSolutionFile = context.OldProject.SolutionPath;

            if (Directory.Exists(newProjectDirectory))
            {
                Directory.Delete(newProjectDirectory, true);
            }

            if (File.Exists(modifiedSolutionFile))
            {
                File.Delete(modifiedSolutionFile);
            }

            // Now rename the backup folders / files to the old names.
            string backupDirectory = string.Format("{0}{1}", context.OldProject.ProjectDirectory, Constants.ProjectDirectoryBackupExtension);
            string backupSolutionFile = string.Format("{0}{1}", context.OldProject.SolutionPath, Constants.SolutionBackupExtension);

            if (Directory.Exists(backupDirectory))
            {
                Directory.Move(backupDirectory, context.OldProject.ProjectDirectory);
            }

            if (File.Exists(backupSolutionFile))
            {
                File.Move(backupSolutionFile, context.OldProject.SolutionPath);
            }

            return true;
        }

        public void UpdateWorkingCopy(string solutionDirectoryPath)
        {
            // Note: An implementation is not needed here.
        }

        private void CreateBackup(Project oldProject)
        {
            // Copy the original directory and all its content before it is renamed.
            string sourceDirectory = oldProject.ProjectDirectory;
            string targetDirectory = string.Format("{0}{1}", oldProject.ProjectDirectory, Constants.ProjectDirectoryBackupExtension);
            copyService.CopyDirectory(sourceDirectory, targetDirectory);

            // Also make a copy of the original solution file.
            string sourceFile = oldProject.SolutionPath;
            string targetFile = string.Format("{0}{1}", oldProject.SolutionPath, Constants.SolutionBackupExtension);
            copyService.CopyFile(sourceFile, targetFile);
        }
    }
}