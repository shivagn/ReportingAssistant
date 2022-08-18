using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Task = Reporting.DomainModels.Task;

namespace Reporting.ServiceContracts
{
    public interface ITasksService
    {
        Task GetTask(long taskID);
        List<Task> GetAllTasks();
        List<Task> GetAllUserTasks(string UserID);
        List<Task> GetAllTasksByDate(DateTime dateTime);
        List<Task> GetAllUsersTasksByDate(string UserId, DateTime date);
        List<Task> GetAllUserTasksByAdmin(string userID, string AdminID, DateTime datetime);
        List<Task> GetAllTasksByProject(long ProjectID);
        long InsertTask(Task task);
        void UpdateTask(Task task);
        void RemoveTask(long taskID);

    }
}
