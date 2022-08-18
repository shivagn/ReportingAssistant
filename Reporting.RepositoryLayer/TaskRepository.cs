using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Reporting.RepositoryContracts;
using Reporting.DataLayer;
using Task = Reporting.DomainModels.Task;


namespace Reporting.RepositoryLayer
{
    public class TaskRepository : ITasksRepository
    {
        ReportingDBContext db;
        public TaskRepository()
        {
            this.db = new ReportingDBContext();
        }
        
        public Task GetTask(long taskID)
        {
            DomainModels.Task task = db.Tasks.FirstOrDefault(temp => temp.TaskID == taskID);
            return task;
        }
        public List<Task> GetAll()
        {
            List<DomainModels.Task> tasks = db.Tasks.ToList();
            return tasks;   
        }

        public List<Task> GetAllUserTasksByAdmin(string userID, string AdminID, DateTime datetiem)
        {
            List<DomainModels.Task> tasks = db.Tasks.Where(temp=>temp.AdminUserID == AdminID && temp.UserID == userID && temp.DateOfTask == datetiem).ToList();
            return tasks;
        }

        public List<Task> GetAllTasksByDate(DateTime dateTime)
        {
            List<DomainModels.Task> tasks = db.Tasks.Where(temp => temp.DateOfTask == dateTime).ToList();
            return tasks;
        }

        public List<Task> GetUserTasks(string UserID)
        {
            List<DomainModels.Task> tasks = db.Tasks.Where(temp => temp.UserID == UserID).ToList();
            return tasks;
        }


        public long Insert(DomainModels.Task task)
        {
          long result = db.Tasks.Add(task).TaskID;
            db.SaveChanges();
            return result;
        }

        public void Remove(long taskID)
        {
            DomainModels.Task task = GetTask(taskID);
            db.Tasks.Remove(task);
            db.SaveChanges();
        }

        public void Update(DomainModels.Task task)
        {
            DomainModels.Task toBeUpdated = GetTask(task.TaskID);
            toBeUpdated.TaskID = task.TaskID;
            toBeUpdated.UserID = task.UserID;
            toBeUpdated.AdminUserID = task.AdminUserID;
            toBeUpdated.DateOfTask = task.DateOfTask;
            toBeUpdated.ProjectID = task.ProjectID;
            toBeUpdated.Attachment = task.Attachment;
            toBeUpdated.Description = task.Description;

            db.SaveChanges();

        }

        public List<DomainModels.Task> GetAllTasksByProject(long ProjectID)
        {
            List<DomainModels.Task> tasks = db.Tasks.Where(temp => temp.ProjectID == ProjectID).ToList();
            return tasks;

        }

        List<Task> ITasksRepository.GetAllUsersTasksByDate(string UserId, DateTime date)
        {
            List<Task> tasks = db.Tasks.Where(temp => temp.UserID == UserId && temp.DateOfTask == date).ToList();
            return tasks;
        }
    }
}
