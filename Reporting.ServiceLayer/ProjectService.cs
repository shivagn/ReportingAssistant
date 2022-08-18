using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Reporting.ServiceContracts;
using Reporting.RepositoryContracts;

namespace Reporting.ServiceLayer
{
    public class ProjectService : IProjectsService
    {
        IProjectsRepository repProject;
        ITasksService tasksService;
        ITasksDoneService tasksDoneService;
        IFinalCommentsService commentsService;
        public ProjectService(IProjectsRepository repProject, ITasksService tasksService, ITasksDoneService taskDone, IFinalCommentsService finalComments)
        {
            this.repProject = repProject;
            this.tasksService = tasksService;  
            this.tasksDoneService = taskDone;
            this.commentsService = finalComments;
        }

        public string DeleteProject(int id)
        {
            Project project = GetProject(id);
            
            int tasksExistNo = tasksService.GetAllTasksByProject(project.ProjectID).Count;
            int tasksDoneExistNo = tasksDoneService.GetTaskDoneByProject(project.ProjectID).Count;
            int commentExistNo = commentsService.GetAllCommentsByProject(project.ProjectID).Count;

            string result = null;

            if (tasksExistNo == 0 && tasksDoneExistNo == 0 && commentExistNo == 0)
            {
                repProject.Delete(id);
                result = "Success";
            }
            else
            {
                string error = null;
                if (tasksExistNo > 0)
                {
                    error = error + tasksExistNo + " Tasks ";
                }
                if (tasksDoneExistNo > 0)
                {
                    error = error + tasksDoneExistNo + " Tasks Done ";
                }
                if (commentExistNo > 0)
                {
                    error = error + tasksDoneExistNo + " Final Comments ";
                }
                result = error;
            }
            return result;
            }

        public List<Project> GetAllProjects()
        {
           return repProject.GetAll();
        }

        public List<Project> GetAllProjectsByCategoryID(long CategoryID)
        {
            List<Project> projects = repProject.GetAll(CategoryID);
            return projects;
        }

        public Project GetProject(int id)
        {
            return repProject.Get(id);
        }

        public Project InsertProject(Project project)
        {
            return repProject.insert(project);
        }

        public void UpdateProject(Project project)
        {
            repProject.Update(project);
        }
    }
}
