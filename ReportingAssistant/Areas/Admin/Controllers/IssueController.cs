using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reporting.DomainModels;
using Reporting.ServiceContracts;
using ReportingAssistant.Filters;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    [MyAuthenticationFilter]
    [AdminAuthorizationFilter]
    public class IssueController : Controller
    {
        IAspNetUsersService userService;
        ITasksService taskService;
        ITasksDoneService taskDoneService;
        IFinalCommentsService finalCommentServ;
        IProjectsService projectsService;

        public IssueController(IAspNetUsersService userService, ITasksService taskService, ITasksDoneService taskDoneService,  IFinalCommentsService finalCommentServ, IProjectsService projectsService)
        {
            this.userService = userService;
            this.taskService = taskService;
            this.taskDoneService = taskDoneService;
            this.finalCommentServ = finalCommentServ;
            this.projectsService = projectsService;

        }

        // GET: Admin/Issue
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Issues()
        {
            ViewBag.Users = userService.usersWithRole("User");
            return View();
            
        }





        [ChildActionOnly]
        public ActionResult DisplayUsersCard(string userID, string userName, DateTime date)
        {
            ViewBag.Date = date;
            ViewBag.day = date.DayOfYear;
            ViewBag.UserID = userID;
            ViewBag.UserName = userName;    
            return PartialView("AccordinDate");
        }
        
        [ChildActionOnly]
        public ActionResult DisplayTasksList(string userID, DateTime date)
        {
            List<Task> UserTasks = taskService.GetAllUsersTasksByDate(userID, date);
            return PartialView("ListTasks", UserTasks);
        }

        [ChildActionOnly]
        public ActionResult DisplaySingleTask(Task task)
        {
            return PartialView("TaskPartial", task);
        }

        [ChildActionOnly]
        public ActionResult DisplayTasksDoneList(string userID, DateTime date)
        { 
            List<TaskDone> TasksDone = taskDoneService.GetAllTasksDone(userID, date);
            return PartialView("ListTasksDone", TasksDone);
        }

        [ChildActionOnly]
        public ActionResult DisplayFinalCommentsList(string UserID, DateTime date)
        {           
            List<FinalComment> finalComments = finalCommentServ.GetAllComments(UserID, date);
            return PartialView("FinalCommentsListPartial", finalComments);
        }

        [ChildActionOnly]
        public ActionResult AddTaskAssigned(string UserID, DateTime date)
        {
            ViewBag.Projects = projectsService.GetAllProjects();
            @ViewBag.Date = date;
            @ViewBag.UserID = UserID;
            return PartialView("AddTaskAssignedPartial");
        }
        [HttpPost]
        public ActionResult AddTaskAssigned(Task task)
        {
            task.AdminUserID =  Session["User"].ToString();
            if (task.Description != null)
            {
                taskService.InsertTask(task);
            }
            else
            {
                ModelState.AddModelError("My Error", "Please insert Task Done Description");
            }
            return RedirectToAction("Issues");
        }

        [ChildActionOnly]
        public ActionResult AddFinalComment(string UserID, DateTime date)
        {
            ViewBag.Projects = projectsService.GetAllProjects();
            @ViewBag.Date = date;
            @ViewBag.UserID = UserID;
            return PartialView("AddFinalCommentPartial");
        }
        [HttpPost]
        public ActionResult AddFinalComment(FinalComment finalComment)
        {
            finalComment.AdminUserID = Session["User"].ToString();
            if (finalComment.Description != null)
            {
                finalCommentServ.InsertComment(finalComment);
            }
            else
            {
                ModelState.AddModelError("My Error", "Please insert Task Done Description");
            }
            return RedirectToAction("Issues");
        }

        [HttpPost]
        public ActionResult UpdateTasks(ICollection<Task> AssignedTasks)
        {
            string Error = null;
            foreach (var item in AssignedTasks)
            {
                if (item.AdminUserID == Session["User"].ToString())
                {
                    Task updateTask = taskService.GetTask(item.TaskID);
                    updateTask.Screen = item.Screen;
                    updateTask.Description = item.Description;
                    taskService.UpdateTask(updateTask);
                }
                else
                {
                    string DefineAdmin = userService.FindUser(item.AdminUserID).UserName;
                    Error = Error + item.Screen + "is defined by" + DefineAdmin + @"! \n";
                }
            }
            if (Error != null)
            {
                ModelState.AddModelError("My Error", Error);
            }
            return RedirectToAction("Issues");
        }

        [HttpPost]
        public ActionResult UpdateFinalComments(ICollection<FinalComment> finalComments)
        {
            string Error = null;
            foreach (var item in finalComments)
            {
                if (item.AdminUserID == Session["User"].ToString())
                {
                    FinalComment updateComments = finalCommentServ.GetFinal(item.FinalCommentID);
                    updateComments.Screen = item.Screen;
                    updateComments.Description = item.Description;
                    finalCommentServ.UpdateComment(updateComments);
                }
                else
                {
                    string DefineAdmin = userService.FindUser(item.AdminUserID).UserName;
                    Error = Error + item.Screen + "is defined by" + DefineAdmin + @"! \n";
                }
            }
            if (Error != null)
            {
                ModelState.AddModelError("My Error", Error);
            }
            ViewBag.MyError = Error;
            return RedirectToAction("Issues");
        }


    }
}