namespace VSPRBase.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using VSPRCommon;
    using VSPRInterfaces;

    internal sealed class ProjectService : IProjectService
    {
        public IList<Project> GetProjects(string solutionpath)
        {
            IList<Project> projects = new List<Project>();

            using(StreamReader reader = new StreamReader(solutionpath))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    if(line.StartsWith("Project("))
                    {
                        Project project = new Project();

                        var buffer = line.Split(new[] { '"' });

                        project.ProjectTypeGuid = Guid.Parse(buffer[1]);
                        project.ProjectName = buffer[3];
                        project.ProjectPath = buffer[5];
                        project.ProjectGuid = Guid.Parse(buffer[7]);
                        projects.Add(project);
                    }
                }
            }

            return projects;
        }
    }
}