namespace VSPRInterfaces
{
	public interface ICopyService
	{
		void CopyDirectory(string sourceDirectory, string targetDirectory);
		void CopyFile(string sourceFile, string targetFile);
	}
}