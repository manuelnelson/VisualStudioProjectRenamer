namespace VSPRBase.Services
{
	using System.Collections.Generic;
	using System.IO;
	using VSPRInterfaces;

	public class CopyService : ICopyService
	{
		private readonly List<string> copyMessages;

		public CopyService()
		{
			copyMessages = new List<string>();
		}

		public void CopyDirectory(string sourceDirectory, string targetDirectory)
		{
			DirectoryInfo source = new DirectoryInfo(sourceDirectory);
			DirectoryInfo target = new DirectoryInfo(targetDirectory);
			CopyAll(source, target);
		}

		public void CopyFile(string sourceFile, string targetFile)
		{
			File.Copy(sourceFile, targetFile, true);
		}

		private void CopyAll(DirectoryInfo source, DirectoryInfo target)
		{
			// Check if the target directory exists, if not, create it.
			if(Directory.Exists(target.FullName) == false)
			{
				Directory.CreateDirectory(target.FullName);
			}

			// Copy each file into it's new directory.
			foreach(FileInfo fileInfo in source.GetFiles())
			{
				copyMessages.Add(string.Format("Copying {0}\\ {1}", target.FullName, fileInfo.Name));
				fileInfo.CopyTo(Path.Combine(target.ToString(), fileInfo.Name), true);
			}

			// Copy each subdirectory using recursion.
			foreach(DirectoryInfo sourceSubdirectory in source.GetDirectories())
			{
				DirectoryInfo targetSubdirectory = target.CreateSubdirectory(sourceSubdirectory.Name);
				CopyAll(sourceSubdirectory, targetSubdirectory);
			}
		}
	}
}