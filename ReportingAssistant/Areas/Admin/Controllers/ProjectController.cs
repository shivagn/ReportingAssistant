using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reporting.DomainModels;
using Reporting.ServiceContracts;
using ReportingAssistant.extentions;
using ReportingAssistant.Filters;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    [MyAuthenticationFilter]
    [AdminAuthorizationFilter]
    public class ProjectController : Controller
    {
        IProjectsService servPro;
        ICategoriesService categoriesService;
        
        public ProjectController(IProjectsService servPro, ICategoriesService categoriesService, ITasksService tasksService, ITasksDoneService tasksDoneService, IFinalCommentsService commentsService)
        {
            this.servPro = servPro;
            this.categoriesService = categoriesService;
        }

        // GET: Admin/Project
        public ActionResult Index()
        {
            List<Project> AllProjects = servPro.GetAllProjects();   
            return View(AllProjects);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = categoriesService.GetAllCategories();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    project.Photo = project.File(file);
                }
                servPro.InsertProject(project);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = categoriesService.GetAllCategories();
            Project project = servPro.GetProject(id);
            return View(project);
        }
        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0 )
                {
                    var file = Request.Files[0];
                    project.Photo = project.File(file);
                }
                servPro.UpdateProject(project);

            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
           Project project = servPro.GetProject(id);
            return View(project);
        }

        public ActionResult Delete(int id)
        {
            Project toBeDeleted = servPro.GetProject(id);
            return View(toBeDeleted);
        }

        [HttpPost]
        public ActionResult Delete(Project project)
        {          
           string result = servPro.DeleteProject(int.Parse(project.ProjectID.ToString()));
            if (result == "Success")
            {
                return RedirectToAction("Index");
            }              
            else
            {                
                ModelState.AddModelError("My Error", "This Project still has " + result + " ,so it cannot be deleted");
                return View();
            }          
        }
    }
}