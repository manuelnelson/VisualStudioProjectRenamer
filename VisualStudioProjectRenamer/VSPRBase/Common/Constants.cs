namespace VSPRBase.Common
{
    internal sealed class Constants
    {
        internal const string AssemblyInfo = "AssemblyInfo.cs";
        internal const string Namespace = "namespace";
        internal const string Using = "using";
        internal const string Global = "global::";

        // Consants for error message
        internal const string NoParentDirectoryFoundError = "No parent directory found for solution {0}.";
        internal const string NoProjectDirectoryFoundError = "No directory with the name {0} was found in the solution directory.";

        // Project file extension constants
        internal const string CSharpProjectFileExtension = ".csproj";
        internal const string VBProjectFileExtension = ".vbproj";

        // General constants
        internal const string CSharpProjectPropertiesDirectory = "Properties";
        internal const string VBProjectMyProjectDirectory = "My Project";
        internal const string CSharpClassFileExtension = ".cs";
        internal const string VBClassFileExtension = ".vb";

        // Named instance names for the service locator
        internal const string SVNRenamer = "SVNRenamer";
        internal const string StandardRenamer = "StandardRenamer";

        // Renamer Update Url
        internal const string UpdateUrl = "http://www.normankosmal.com/RaZeR/VSPR/Update/versioninfo.xml";
        internal const string LocalUpdateUrl = "http://localhost:8008/VSPR/Update/versioninfo.xml";

        // Backup extensions
        internal const string ProjectDirectoryBackupExtension = "_BAK";
        internal const string SolutionBackupExtension = ".bak";
    }
}