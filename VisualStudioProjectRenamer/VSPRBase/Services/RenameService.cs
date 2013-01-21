namespace VSPRBase.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Xml;
	using Common;
	using VSPRCommon;
	using VSPRCommon.Enums;
	using VSPRCommon.EventArguments;
	using VSPRInterfaces;

	internal sealed class RenameService : IRenameService
	{
		private readonly IErrorDialogService errorDialogService;
		private readonly IGuard guard;
		private readonly ILocalizationService localizationService;
        private readonly IProjectService projectService;
		private readonly IRenamerFactory renamerFactory;
		private IRenamer renamer;
		private string solutionDirectoryPath;
		private string solutionPath;
		private RenameContext context;

		public RenameService(IErrorDialogService errorDialogService, IGuard guard, IRenamerFactory renamerFactory, ILocalizationService localizationService, IProjectService projectService)
		{
			this.errorDialogService = errorDialogService;
			this.guard = guard;
			this.renamerFactory = renamerFactory;
			this.localizationService = localizationService;
		    this.projectService = projectService;
		}

		public event EventHandler<RenameFinishedEventArgs> RenameFinished;

		public void InvokeRenameFinished(RenameFinishedEventArgs args)
		{
			EventHandler<RenameFinishedEventArgs> handler = RenameFinished;
			if(handler != null)
			{
				handler(this, args);
			}
		}

		public void Rename(RenameContext renameContext)
		{
			bool renameSuccessfull = true;
			bool rollbackSuccessfull = true;

			this.context = renameContext;

			try
			{
				if(Setup(this.context.Solution))
				{
					renamer = renamerFactory.GetInstance(this.context.IsUnderVersionControl);
					Rename(this.context.CommitChanges);
				}
				else
				{
					string message = string.Format(localizationService.GetString(LocalizationResourceNames.RenameErrorNoSupportedProjectFound), context.OldProject.ProjectDirectory);
					errorDialogService.HandleError(message);
					renameSuccessfull = false;
				}
			}
			catch(Exception exception)
			{
				renameSuccessfull = false;
				errorDialogService.HandleError(string.Format("Exception:{0}{1}{2}Stacktrace:{3}{4}{5}", Environment.NewLine, exception.Message, Environment.NewLine, Environment.NewLine, exception.StackTrace, Environment.NewLine));
				rollbackSuccessfull = Rollback();
			}
			finally
			{
				InvokeRenameFinished(new RenameFinishedEventArgs(true, renameSuccessfull, rollbackSuccessfull));
			}
		}

		private void Rename(bool commitChanges)
		{
			renamer.UpdateWorkingCopy(solutionDirectoryPath);

			renamer.RenameProjectFolder(context);
			renamer.RenameProjectFile(context);
			renamer.RenameProjectFiltersFile(context);
			renamer.RenameMainEntryFile(context);

			// Since we maybe have renamed the main entry file of c++ projects, we need to adjust the
			// reference to that file in the project file.
			ReplaceReferencesToMainEntryFileInProjectFile();

			ReplaceProjectReferencesInSolutionFile();
			ReplaceOccurencesInProjectFile();
			ReplaceOccurencesInSpecialFiles();
			ReplaceOccurencesInNameSpaces();
			ReplaceOccurencesInUsingBlocks();
			ReplaceOccurencesInGlobalDeclarations();

            //We need to cycle through other projects in solution file
            //var projects = projectService.GetProjects(context.Solution);
            //foreach (var project in projects)
            //{
            //    UpdateProjectReferences(project.ProjectFile);
            //    UpdateOccurencesIn
            //}
            
            if (commitChanges)
			{
				renamer.CheckInChanges(solutionDirectoryPath, context.OldProject, context.NewProject);
			}

			// Now cleanup all backed up ressources (this is only implemented in the StandardRenamer).
			renamer.Cleanup(context.OldProject);
		}

	    private void ReplaceReferencesToMainEntryFileInProjectFile()
		{
			// Only try this for c++ projects and if renameMainEntryFile was checked and renamed previously in 
			// the previous method.
			if(context.OldProject.ProjectType.Equals(ProjectType.Cplusplus) && context.RenameMainEntryFile)
			{
				string searchFor = string.Format("{0}{1}", context.OldProject.ProjectName, ".cpp");
				string replaceWith = string.Format("{0}{1}", context.NewProject.ProjectName, ".cpp");

				Replace(context.NewProject.ProjectFile, searchFor, replaceWith);
			}
		}

		/// <summary>
		/// Replaces occurences of a string with another string in the specified file
		/// using a regular expression.
		/// </summary>
		/// <param name="file"></param>
		/// <param name="searchFor"></param>
		/// <param name="replaceWith"></param>
		private void Replace(string file, string searchFor, string replaceWith)
		{
			string fileContent;

			using(StreamReader reader = new StreamReader(file))
			{
				fileContent = reader.ReadToEnd();
			}

			// Use regular expressions to search and replace text
			fileContent = Regex.Replace(fileContent, searchFor, replaceWith);

			// Write modified file content back to file
			using(StreamWriter writer = new StreamWriter(file))
			{
				writer.Write(fileContent);
			}
		}

		private void ReplaceOccurencesInNameSpaces()
		{
			string[] files;
			string searchFor;
			string replaceWith;

			// Special treatment of C++ Projects.. // TODO NKO Refactor this 
			if(context.OldProject.ProjectType.Equals(ProjectType.Cplusplus))
			{
				files = Directory.GetFiles(context.NewProject.ProjectDirectory, "*", SearchOption.AllDirectories);

				searchFor = string.Format("{0} {1} {2}", "namespace", context.OldProject.ProjectName, "{");
				replaceWith = string.Format("{0} {1} {2}", "namespace", context.NewProject.ProjectName, "{");

				foreach(string file in files)
				{
					// Skip these files..
					if(!file.EndsWith(".rc") && !file.EndsWith(".ico") && !file.EndsWith(".resX"))
					{
						Replace(file, searchFor, replaceWith);
					}
				}

				return;
			}

			// For every other project for now this is the way to go..
			files = Directory.GetFiles(context.NewProject.ProjectDirectory,
				string.Format("*{0}", context.NewProject.ClassfileExtension), SearchOption.AllDirectories);

			searchFor = string.Format("{0} {1}", Constants.Namespace, context.OldProject.ProjectName);
			replaceWith = string.Format("{0} {1}", Constants.Namespace, context.NewProject.ProjectName);

			foreach(string file in files)
			{
				Replace(file, searchFor, replaceWith);
			}
		}

        //private void UpdateProjectReferences(string projectFile)
        //{
        //    Replace(projectFile, context.OldProject.ProjectName, context.NewProject.ProjectName);
        //}

		private void ReplaceOccurencesInProjectFile()
		{
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.Load(context.NewProject.ProjectFile);

			XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmldoc.NameTable);
			namespaceManager.AddNamespace("x", "http://schemas.microsoft.com/developer/msbuild/2003");

			XmlNodeList nodes = xmldoc.SelectNodes("//x:RootNamespace", namespaceManager);
			if(nodes != null)
			{
				foreach(XmlNode item in nodes)
				{
					item.InnerText = context.NewProject.ProjectName;
				}
			}

			nodes = xmldoc.SelectNodes("//x:AssemblyName", namespaceManager);
			if(nodes != null)
			{
				foreach(XmlNode item in nodes)
				{
					item.InnerText = context.NewProject.ProjectName;
				}
			}

			xmldoc.Save(context.NewProject.ProjectFile);
		}

		/// <summary>
		/// This attempts to replace occurences in special folders such as the Properties folder or 
		/// Myproject folder if its a vb project.
		/// </summary>
		private void ReplaceOccurencesInSpecialFiles()
		{
			string directory;
			List<string> files;

			switch(context.OldProject.ProjectType)
			{
				case ProjectType.CSharp:
					directory = string.Format("{0}{1}{2}", context.NewProject.ProjectDirectory, "\\", Constants.CSharpProjectPropertiesDirectory);
					files = Directory.GetFiles(directory, Constants.AssemblyInfo).ToList();
					if(files.Count == 1)
					{
						Replace(files[0], context.OldProject.ProjectName, context.NewProject.ProjectName);
					}
					break;

				case ProjectType.VB:
					directory = string.Format("{0}{1}{2}", context.NewProject.ProjectDirectory, "\\", Constants.VBProjectMyProjectDirectory);
					files = Directory.GetFiles(directory).ToList();
					foreach(string file in files)
					{
						Replace(file, context.OldProject.ProjectName, context.NewProject.ProjectName);
					}
					break;

				case ProjectType.Cplusplus:
					files = Directory.GetFiles(context.NewProject.ProjectDirectory).ToList();
					foreach(string file in files)
					{
						if(file.EndsWith("AssemblyInfo.cpp"))
						{
							Replace(file, context.OldProject.ProjectName, context.NewProject.ProjectName);
						}
					}
					break;
			}
		}

		private void ReplaceOccurencesInUsingBlocks()
		{
			string[] files;
			string searchFor;
			string replaceWith;

			if(this.context.OldProject.ProjectType.Equals(ProjectType.Cplusplus))
			{
				files = Directory.GetFiles(context.NewProject.ProjectDirectory, "*", SearchOption.AllDirectories);

				searchFor = string.Format("{0} {1}{2}", "using namespace", context.OldProject.ProjectName, ";");
				replaceWith = string.Format("{0} {1}{2}", "using namespace", context.NewProject.ProjectName, ";");

				foreach(string file in files)
				{
					// Ommit these files..
					if(!file.EndsWith(".rc") && !file.EndsWith(".ico") && !file.EndsWith(".resX"))
					{
						Replace(file, searchFor, replaceWith);
					}
				}
			}

			files = Directory.GetFiles(context.NewProject.ProjectDirectory, string.Format("*{0}", context.NewProject.ClassfileExtension), SearchOption.AllDirectories);

			searchFor = string.Format("{0} {1}", Constants.Using, context.OldProject.ProjectName);
			replaceWith = string.Format("{0} {1}", Constants.Using, context.NewProject.ProjectName);

			foreach(string file in files)
			{
				Replace(file, searchFor, replaceWith);
			}
		}

		private void ReplaceOccurencesInGlobalDeclarations()
		{
			string[] files = Directory.GetFiles(context.NewProject.ProjectDirectory, string.Format("*{0}", context.NewProject.ClassfileExtension), SearchOption.AllDirectories);

			string searchFor = string.Format("{0}{1}", Constants.Global, context.OldProject.ProjectName);
			string replaceWith = string.Format("{0}{1}", Constants.Global, context.NewProject.ProjectName);

			foreach(string file in files)
			{
				Replace(file, searchFor, replaceWith);
			}
		}

		private void ReplaceProjectReferencesInSolutionFile()
		{
			Replace(solutionPath, context.OldProject.ProjectName, context.NewProject.ProjectName);
		}

		private bool Rollback()
		{
			bool success;
			try
			{
				success = renamer.Rollback(solutionDirectoryPath, context);
			}
			catch(Exception exception)
			{
				string message = string.Format(localizationService.GetString(LocalizationResourceNames.RevertErrorMessage), exception.Message);
				errorDialogService.HandleError(message);
				success = false;
			}

			return success;
		}

		private void SetDirectories()
		{
			// TODO NKO Refactor this..actually read the folder name from the solution file instead of assuming there is a folder with the projectname in the root..
			// Get the absolute path to the solution directory from the solution path
			DirectoryInfo solutionDirectory = Directory.GetParent(solutionPath);
			if(solutionDirectory != null && !string.IsNullOrEmpty(solutionDirectory.FullName))
			{
				solutionDirectoryPath = solutionDirectory.FullName;
			}
			else
			{
				// There was no directory found (This should actually not be happening)
				string message = string.Format(Constants.NoParentDirectoryFoundError, solutionDirectory);
				throw new ArgumentException(message);
			}

			// Find exactly one directory within the solution directory, that has the old project name
			List<string> directories = Directory.GetDirectories(solutionDirectoryPath, context.OldProject.FolderName, SearchOption.TopDirectoryOnly).ToList();
			if(directories.Count == 1)
			{
				// Set the old project directory
				context.OldProject.ProjectDirectory = directories[0];

				// Set the new project directory
				context.NewProject.ProjectDirectory = string.Format("{0}{1}{2}", Directory.GetParent(context.OldProject.ProjectDirectory), "\\", context.NewProject.ProjectName);
			}
			else
			{
				// There was no directory found in the solution directory, that contains the old project name.
				string message = string.Format(Constants.NoProjectDirectoryFoundError, context.OldProject.ProjectName);
				throw new ArgumentException(message);
			}
		}

		private bool Setup(string solutionFilePath)
		{
			guard.FileExists(solutionFilePath);
			solutionPath = solutionFilePath;

			context.NewProject.ProjectTypeGuid = context.OldProject.ProjectTypeGuid;
			context.OldProject.SolutionPath = solutionFilePath;
			context.NewProject.SolutionPath = solutionFilePath;

			SetDirectories();

			// return true if the project type is supported.
			return !context.OldProject.ProjectType.Equals(ProjectType.NotSupported);
		}
	}
}