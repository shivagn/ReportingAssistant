using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Reporting.ServiceContracts;
using Reporting.RepositoryContracts;
using Task = Reporting.DomainModels.Task;

namespace Reporting.ServiceLayer
{
    public class TaskService : ITasksService
    {
        ITasksRepository tasksRep;
        public TaskService(ITasksRepository tasksRep)
        {
            this.tasksRep = tasksRep;   
        }
        public List<Task> GetAllTasks()
        {
            List<Task> tasks = tasksRep.GetAll();
            return tasks;
        }

        public List<Task> GetAllTasksByDate(DateTime dateTime)
        {
            List<Task> tasks = tasksRep.GetAllTasksByDate(dateTime);
            return tasks;
        }

        public List<Task> GetAllUsersTasksByDate(string UserId, DateTime date)
        {
            List<Task> tasks = tasksRep.GetAllUsersTasksByDate(UserId, date);
            return tasks;
        }

        public List<Task> GetAllTasksByProject(long ProjectID)
        {
            List<Task> tasks = tasksRep.GetAllTasksByProject(ProjectID);
            return tasks;
        }

        public List<Task> GetAllUserTasks(string UserID)
        {
            List<Task> tasks = tasksRep.GetUserTasks(UserID);
            return tasks;   
        }

        public List<Task> GetAllUserTasksByAdmin(string userID, string AdminID, DateTime datetime)
        {
            List<Task> tasks = tasksRep.GetAllUserTasksByAdmin(userID, AdminID, datetime);
            return tasks;
        }

        public Task GetTask(long taskID)
        {
            Task task = tasksRep.GetTask(taskID);
            return task;
        }

        public long InsertTask(Task task)
        {
            long Id = tasksRep.Insert(task);
            return Id;
        }

        public void RemoveTask(long taskID)
        {
            tasksRep.Remove(taskID);
        }

        public void UpdateTask(Task task)
        {
            tasksRep.Update(task);
        }
    }
}
