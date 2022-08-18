using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Task = Reporting.DomainModels.Task;

namespace Reporting.RepositoryContracts
{
    public interface ITasksRepository
    {
        Task GetTask(long taskID);
        List<Task> GetAll();
        List<Task> GetUserTasks(string UserID);
        List<Task> GetAllTasksByDate(DateTime dateTime);
        List<Task> GetAllUsersTasksByDate(string UserId, DateTime date);
        List<Task> GetAllUserTasksByAdmin(string userID, string AdminID, DateTime datetime);
        List<Task> GetAllTasksByProject(long ProjectID);
        long Insert(Task task);
        void Update(Task task);
        void Remove(long taskID);

    }
}
