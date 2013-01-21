namespace VSPRInterfaces
{
    using System.Collections.Generic;
    using VSPRCommon;

    public interface IProjectService
    {
        IList<Project> GetProjects(string solutionpath);
    }
}