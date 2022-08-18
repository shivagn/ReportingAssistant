using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;

namespace Reporting.RepositoryContracts
{
    public interface ITasksDoneRepository
    {
        TaskDone Get(long id);
        List<TaskDone> GetAll();
        List<TaskDone> GetAll(string userID);
        List<TaskDone> GetAll(string userID, DateTime date);
        List<TaskDone> GetAll(long ProjectID);
        void Delete(long id);
        TaskDone insert (TaskDone taskDone);
        void update (TaskDone taskDone);
    }
}
