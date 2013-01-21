namespace VSPRCommon
{
    using System;
    using Enums;

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/bb165951%28v=vs.80%29.aspx
    /// http://www.mztools.com/articles/2008/mz2008017.aspx
    /// 
    /// example: Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "VSPRBase", "VSPRBase\VSPRBase.csproj", "{C1F9CA6F-E0B9-4BE3-9F14-855A2B51FD48}"
    /// </summary>
    public class Project
    {
        /// <summary>
        /// The guid of the project.
        /// </summary>
        public Guid ProjectGuid { get; set; }

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// The relative path to the project in relation to the solution file.
        /// </summary>
        public string ProjectPath { get; set; }

        public string FolderName { get { return GetOrginalFolderName(); } }

        /// <summary>
        /// The type of the project.
        /// </summary>
        public Guid ProjectTypeGuid { get; set; }

        /// <summary>
        /// Absolute path to the project directory
        /// </summary>
        public string ProjectDirectory { get; set; }

        /// <summary>
        /// Absolute Path to the solution file.
        /// </summary>
        public string SolutionPath { get; set; }

        /// <summary>
        /// Returns the project type from the ProjectTypeGuid.
        /// </summary>
        /// <returns></returns>
        public ProjectType ProjectType
        {
            get
            {
                ProjectType value;

                switch(ProjectTypeGuid.ToString().ToUpper())
                {
                    // CSharp project
                    case "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC":
                        value = ProjectType.CSharp;
                        break;

                    // VB project
                    case "F184B08F-C81C-45F6-A57F-5ABD9991F28F":
                        value = ProjectType.VB;
                        break;

                    // C++  project
                    case "8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942":
                        value = ProjectType.Cplusplus;
                        break;

                    default:
                        value = ProjectType.NotSupported;
                        break;
                }

                return value;
            }
        }

        /// <summary>
        /// Returns the project type from the ProjectTypeGuid.
        /// </summary>
        /// <returns></returns>
        public string ProjectExtension
        {
            get
            {
                string value;

                switch(ProjectTypeGuid.ToString().ToUpper())
                {
                    // CSharp project
                    case "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC":
                        value = ".csproj";
                        break;

                    // VB project
                    case "F184B08F-C81C-45F6-A57F-5ABD9991F28F":
                        value = ".vbproj";
                        break;
                    
                    // C++  project
                    case "8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942":
                        value = ".vcxproj";
                        break;

                    default:
                        value = string.Empty;
                        break;
                }

                return value;
            }
        }

        /// <summary>
        /// Returns the project type from the ProjectTypeGuid.
        /// </summary>
        /// <returns></returns>
        public string ClassfileExtension
        {
            get
            {
                string value;

                switch(ProjectTypeGuid.ToString().ToUpper())
                {
                    // CSharp project
                    case "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC":
                        value = ".cs";
                        break;

                    // VB project
                    case "F184B08F-C81C-45F6-A57F-5ABD9991F28F":
                        value = ".vb";
                        break;

                    // C++  project
                    case "8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942":
                        value = ".cpp";
                        break;

                    default:
                        value = string.Empty;
                        break;
                }

                return value;
            }
        }

        public string ProjectFile
        {
            get { return string.Format("{0}{1}{2}{3}", ProjectDirectory, "\\", ProjectName, ProjectExtension); }
        }

        /// <summary>
        ///  Returns true whenever the project file is called the same as the project folder.
        /// </summary>
        /// <returns></returns>
        public bool FolderNameEqualsProjectName()
        {
            return ProjectName.Equals(FolderName);
        }

        private string GetOrginalFolderName()
        {
            var buffer = ProjectPath.Split(new[] { '\\' });

            return buffer[0];
        }
    }
}