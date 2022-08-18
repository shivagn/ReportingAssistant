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
    public class CategoryController : Controller
    {
        ICategoriesService servCat;
        IProjectsService servPro;
        public CategoryController(ICategoriesService servCat, IProjectsService servPro)
        {
            this.servCat = servCat;
            this.servPro = servPro;
        }


        // GET: Admin/Category
        public ActionResult Index()
        {
            List<Category> allCategories = servCat.GetAllCategories();
            return View(allCategories);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            servCat.InsertCategory(category);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
           Category toBeDeleted = servCat.GetCategoy(long.Parse(id.ToString()));
            return View(toBeDeleted);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            List<Project> allProjects = servPro.GetAllProjectsByCategoryID(category.CategoryID);
            if (allProjects.Count == 0)
            {
                servCat.DeleteCategory(long.Parse(category.CategoryID.ToString()));
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Error", "This Category is assigned to " + allProjects.Count + "Projects and cannot be deleted");
                return View(category);
            }
           

        }
        public ActionResult Edit(int id)
        {
            Category category = servCat.GetCategoy(long.Parse(id.ToString()));
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            servCat.UpdateCategory(category);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Category category = servCat.GetCategoy(long.Parse(id.ToString()));
            return View(category);
        }

        public ActionResult Search(string name)
        {
           List<Category> results = servCat.SerachCategories(name);
            return View(results);

        }
    }
}