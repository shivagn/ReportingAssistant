using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Reporting.RepositoryContracts;
using Reporting.ServiceContracts;

namespace Reporting.ServiceLayer
{
    public class TaskDoneService : ITasksDoneService
    {
        ITasksDoneRepository tasksDoneRep;
        public TaskDoneService(ITasksDoneRepository tasksDoneRep)
        {
            this.tasksDoneRep = tasksDoneRep;
        }
        public void DeleteTaskDone(long id)
        {
            tasksDoneRep.Delete(id);
        }

        public List<TaskDone> GetAllTasksDone()
        {
            List<TaskDone> AllTasks = tasksDoneRep.GetAll();
            return AllTasks;
        }

        public List<TaskDone> GetAllTasksDone(string userID)
        {
            List<TaskDone> AllTasks = tasksDoneRep.GetAll(userID);
            return AllTasks;
        }

        public List<TaskDone> GetAllTasksDone(string userID, DateTime date)
        {
            List<TaskDone> AllTasks = tasksDoneRep.GetAll(userID, date);
            return AllTasks;
        }

        public TaskDone GetTaskDone(long id)
        {
            TaskDone taskDone = tasksDoneRep.Get(id);
            return taskDone;
        }

        public List<TaskDone> GetTaskDoneByProject(long projectID)
        {
            List<TaskDone> tasksDone = tasksDoneRep.GetAll(projectID);
            return tasksDone;
        }

        public TaskDone InsertTaskDone(TaskDone taskDone)
        {
            TaskDone result = tasksDoneRep.insert(taskDone);
            return result;
        }

        public void UpdateTaskDone(TaskDone taskDone)
        {
            tasksDoneRep.update(taskDone);
        }
    }
}
