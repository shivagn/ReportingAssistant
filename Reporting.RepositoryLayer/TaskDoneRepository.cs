using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.RepositoryContracts;
using Reporting.DataLayer;
using Reporting.DomainModels;

namespace Reporting.RepositoryLayer
{
    public class TaskDoneRepository : ITasksDoneRepository
    {
        ReportingDBContext db;
        public TaskDoneRepository()
        {
            db = new ReportingDBContext();
        }

        public void Delete(long id)
        {
            TaskDone taskDone = Get(id);
            db.TasksDone.Remove(taskDone);
            db.SaveChanges();
        }

        public TaskDone Get(long id)
        {
            TaskDone taskDone = db.TasksDone.FirstOrDefault(temp => temp.TaskDoneID == id);
            return taskDone;
        }

        public List<TaskDone> GetAll()
        {
            List<TaskDone> tasksDone = db.TasksDone.ToList();
            return tasksDone;
        }

        public List<TaskDone> GetAll(string userID)
        {
            List<TaskDone> tasksDone = db.TasksDone.Where(temp=>temp.UserID == userID).ToList();
            return tasksDone;
        }

        public List<TaskDone> GetAll(string userID, DateTime date)
        {
            List<TaskDone> tasksDone = db.TasksDone.Where(temp => temp.UserID == userID && temp.DateOfTaskDone == date).ToList();
            return tasksDone;
        }

        public List<TaskDone> GetAll(long ProjectID)
        {
            List<TaskDone> tasks = db.TasksDone.Where(temp => temp.ProjectID == ProjectID).ToList();
            return tasks;
        }

        public TaskDone insert(TaskDone taskDone)
        {
            TaskDone t = db.TasksDone.Add(taskDone);
            db.SaveChanges();
            return t;
        }

        public void update(TaskDone taskDone)
        {
            TaskDone toBeEdited = Get(taskDone.TaskDoneID);
            toBeEdited.DateOfTaskDone = taskDone.DateOfTaskDone;
            toBeEdited.Description = taskDone.Description;
            toBeEdited.Screen = taskDone.Screen;
            toBeEdited.ProjectID = taskDone.ProjectID;
            toBeEdited.UserID = taskDone.UserID;
            toBeEdited.Attachment = taskDone.Attachment;
            db.SaveChanges();

        }
    }
}
