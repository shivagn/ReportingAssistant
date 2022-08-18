using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;

namespace Reporting.ServiceContracts
{
    public interface IProjectsService
    {
        Project GetProject(int id);
        List<Project> GetAllProjects();
        string DeleteProject(int id);
        void UpdateProject(Project project);
        Project InsertProject(Project project);
        List<Project> GetAllProjectsByCategoryID(long CategoryID);
    }
}
