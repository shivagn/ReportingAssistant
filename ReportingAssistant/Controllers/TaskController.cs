using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reporting.DomainModels;
using Reporting.ServiceContracts;
using ReportingAssistant.Filters;


namespace ReportingAssistant.Controllers
{
    [MyAuthenticationFilter]
    [UserAuthorizationFilter]
    public class TaskController : Controller
    {
        ITasksService tasksService;
        IAspNetUsersService userService;
        IAspNetRolesService roleServ;
        ITasksDoneService tasksDoneService;
        IProjectsService projectsService;
        IFinalCommentsService finalCommentsService;
        public TaskController(ITasksService taskServ, IAspNetUsersService userServ, IAspNetRolesService roleServ, ITasksDoneService tasksDoneService, IProjectsService projectsService, IFinalCommentsService finalCommentsService)
        {
            this.tasksService = taskServ;
            this.userService = userServ;
            this.roleServ = roleServ;
            this.tasksDoneService = tasksDoneService;
            this.projectsService = projectsService;
            this.finalCommentsService = finalCommentsService;   
        }
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Issues()
        {
            ViewBag.Today = DateTime.Today;
            ViewBag.Yesterday = DateTime.Today.AddDays(-1);
            ViewBag.Admins = userService.usersWithRole("Admin");
            return View();
        }

        [HttpPost]
        public ActionResult Issues(List<TaskDone> tasksDone)
        {
            return View();
        }



        [ChildActionOnly]
        public ActionResult DisplayTasksList(string AdminID, DateTime date)
        {
            string userId = userService.FindUserByName("shi").Id; //Session["User"].ToString();
            List<Task> AssignedTasks = tasksService.GetAllUserTasksByAdmin(userId, AdminID, date);
            return PartialView("ListTasks", AssignedTasks);
        }

        [ChildActionOnly]
        public ActionResult DisplaySingleTask(Task task)
        {
            return PartialView("TaskPartial", task);
        }

        [ChildActionOnly]
        public ActionResult DisplayTasksDoneList(DateTime date)
        {
            string userId = userService.FindUserByName("shi").Id;// Session["User"].ToString();
            List<TaskDone> TasksDone = tasksDoneService.GetAllTasksDone(userId, date);           
            return PartialView("ListTasksDone", TasksDone);
        }

        [ChildActionOnly]
        public ActionResult DisplayFinalCommentsList(string AdminID, DateTime date)
        {
            string userId = userService.FindUserByName("shi").Id; //Session["User"].ToString();
            List<FinalComment> finalComments = finalCommentsService.GetAllComments(userId, AdminID, date);
            return PartialView("FinalCommentsListPartial", finalComments);
        }

        [ChildActionOnly]
        public ActionResult AddTaskDone(DateTime date)
        {
            ViewBag.Projects = projectsService.GetAllProjects();
            ViewBag.Date = date;
            return PartialView("AddTaskDonePartial");
        }
        
        [HttpPost]
        public ActionResult AddTaskDone(TaskDone taskDone)
        {
            taskDone.UserID = userService.FindUserByName("shi").Id;// Session["User"].ToString();
            if (taskDone.Description != null)
            {
                tasksDoneService.InsertTaskDone(taskDone);
            }
            else
            {
                ModelState.AddModelError("My Error", "Please insert Task Done Description");               
            }
             return RedirectToAction("Issues");
        }

        public ActionResult Save(ICollection<TaskDone> tasksDone)
        {            
            foreach (var item in tasksDone)
            {
                TaskDone td = tasksDoneService.GetTaskDone(item.TaskDoneID);
                td.Screen = item.Screen;
                td.Description = item.Description;
                td.DateOfTaskDone = item.DateOfTaskDone;
                tasksDoneService.UpdateTaskDone(td);
            }
            return RedirectToAction("Issues");
        }

    }
}