using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;


namespace Reporting.ServiceContracts
{
    public interface ITasksDoneService
    {
        TaskDone GetTaskDone(long id);
        List<TaskDone> GetAllTasksDone();
        List<TaskDone> GetAllTasksDone(string userID);
        List<TaskDone> GetAllTasksDone(string userID, DateTime date);
        List<TaskDone> GetTaskDoneByProject(long projectID);
        void DeleteTaskDone(long id);
        TaskDone InsertTaskDone(TaskDone taskDone);
        void UpdateTaskDone(TaskDone taskDone);
    }
}
