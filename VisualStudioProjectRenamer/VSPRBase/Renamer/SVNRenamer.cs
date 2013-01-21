namespace VSPRBase.Renamer
{
	using System.Collections.ObjectModel;
	using System.IO;
	using SharpSvn;
	using VSPRCommon;
	using VSPRCommon.Enums;
	using VSPRInterfaces;

	internal sealed class SVNRenamer : IRenamer
	{
		public void CheckInChanges(string solutionDirectoryPath, Project oldProject, Project newProject)
		{
			using(SvnClient svnClient = new SvnClient())
			{
				SvnCommitArgs svnCommitArgs = new SvnCommitArgs { LogMessage = string.Format("Renamed project {0} into {1}", oldProject.ProjectName, newProject.ProjectName) };

				// TODO NKO: Do something with the result
				SvnCommitResult result;
				svnClient.Commit(solutionDirectoryPath, svnCommitArgs, out result);
			}
		}

		public void Cleanup(Project project)
		{
			// Note: An implementation is not needed here.
		}

	    public void RenameMainEntryFile(RenameContext context)
	    {
            string oldMainEntryFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.OldProject.ProjectName, ".cpp");
            string newMainEntryFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.NewProject.ProjectName, ".cpp");

            // Only if the main entry file in c++ projects has the same name as the project itself, move it.
            if(File.Exists(oldMainEntryFile))
            {
                using (SvnClient svnClient = new SvnClient())
                {
                    svnClient.Move(oldMainEntryFile, newMainEntryFile);
                }  
            }
	    }

	    public void RenameProjectFile(RenameContext context)
		{
            string oldProjectFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.OldProject.ProjectName, context.OldProject.ProjectExtension);
            string newProjectFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.NewProject.ProjectName, context.NewProject.ProjectExtension);

            if (File.Exists(oldProjectFile))
            {
                using (SvnClient svnClient = new SvnClient())
                {
                    svnClient.Move(oldProjectFile, newProjectFile);
                }
            }
		}

		public void RenameProjectFiltersFile(RenameContext context)
		{
			if(!context.OldProject.ProjectType.Equals(ProjectType.Cplusplus))
			{
				return;
			}

			string oldProjectFiltersFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.OldProject.ProjectName, ".vcxproj.filters");
			string newProjectFiltersFile = string.Format("{0}{1}{2}{3}", context.NewProject.ProjectDirectory, "\\", context.NewProject.ProjectName, ".vcxproj.filters");

            if (File.Exists(oldProjectFiltersFile))
            {
                using (SvnClient svnClient = new SvnClient())
                {
                    svnClient.Move(oldProjectFiltersFile, newProjectFiltersFile);
                }
            }
		}

		public void RenameProjectFolder(RenameContext context)
		{
			using(SvnClient svnClient = new SvnClient())
			{
				svnClient.Move(context.OldProject.ProjectDirectory, context.NewProject.ProjectDirectory);
			}
		}

		public bool Rollback(string solutionDirectoryPath, RenameContext context)
		{
			using(SvnClient svnClient = new SvnClient())
			{
				// TODO NKO Do someting with the changelist
				Collection<SvnListChangeListEventArgs> changeList;
				svnClient.GetChangeList(solutionDirectoryPath, out changeList);

				SvnRevertArgs revertArgs = new SvnRevertArgs { Depth = SvnDepth.Infinity };
				svnClient.Revert(solutionDirectoryPath, revertArgs);
			}

			// Now delete the folder that was created for the new project.
			// Note: Can not use svnclient.Delete because the folder and all containing files werent ever checked in.
			Directory.Delete(context.NewProject.ProjectDirectory, true);

			// And do an update to get a clean repository state again.
			UpdateWorkingCopy(solutionDirectoryPath);

			return true;
		}

		public void UpdateWorkingCopy(string solutionDirectoryPath)
		{
			using(SvnClient svnClient = new SvnClient())
			{
				// TODO NKO: Do something with the result
				SvnUpdateResult result;
				svnClient.Update(solutionDirectoryPath, out result);
			}
		}
	}
}