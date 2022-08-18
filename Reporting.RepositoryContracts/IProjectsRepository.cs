using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;

namespace Reporting.RepositoryContracts
{
    public interface IProjectsRepository
    {
        Project Get(int id);
        List<Project> GetAll();
        void Delete(int id);
        void Update(Project project);   
        Project insert(Project project);
        List<Project> GetAll(long categoryID);


    }
}
