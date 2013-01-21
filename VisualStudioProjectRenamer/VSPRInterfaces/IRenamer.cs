namespace VSPRInterfaces
{
	using VSPRCommon;

	public interface IRenamer
	{
		void CheckInChanges(string solutionDirectoryPath, Project oldProject, Project newProject);
        void RenameProjectFile(RenameContext context);
	    void RenameProjectFiltersFile(RenameContext context);
		void RenameProjectFolder(RenameContext context);
		void UpdateWorkingCopy(string solutionDirectoryPath);
		bool Rollback(string solutionDirectoryPath, RenameContext context);
		void Cleanup(Project project);
	    void RenameMainEntryFile(RenameContext context);
	}
}