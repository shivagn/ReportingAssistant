using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Reporting.DataLayer;
using Reporting.RepositoryContracts;

namespace Reporting.RepositoryLayer
{
    public class ProjectRepository : IProjectsRepository
    {
        ReportingDBContext db;
        public ProjectRepository()
        {
            this.db = new ReportingDBContext();
        }

        public void Delete(int id)
        {
            Project toBeDeleted = Get(id);
            db.Projects.Remove(toBeDeleted);
            db.SaveChanges();
        }

        public Project Get(int id)
        {
            long selectedProID = long.Parse(id.ToString());
            Project project = db.Projects.FirstOrDefault(temp => temp.ProjectID == selectedProID);
            return project;
        }

        public List<Project> GetAll()
        {
            List<Project> projects = db.Projects.ToList();
            return projects;
        }

        public List<Project> GetAll(long categoryID)
        {
            List<Project> projects = db.Projects.Where(temp => temp.CategoryID == categoryID).ToList();
            return projects;
        }

        public Project insert(Project project)
        {
            Project insertedProject = db.Projects.Add(project);
            db.SaveChanges();
            return insertedProject;
        }

        public void Update(Project project)
        {
            int proID = int.Parse(project.ProjectID.ToString());
            Project toBeEdited = Get(proID);
            toBeEdited.ProjectName = project.ProjectName;
            toBeEdited.Photo = project.Photo;
            toBeEdited.DateOfStart = project.DateOfStart;
            toBeEdited.AvailabilityStatus = project.AvailabilityStatus;
            toBeEdited.CategoryID = project.CategoryID;
            db.SaveChanges();
        }
    }
}
