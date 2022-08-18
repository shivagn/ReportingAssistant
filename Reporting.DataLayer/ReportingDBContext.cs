using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels;
using Reporting.DomainModels.Identity;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Reporting.DataLayer
{
    public class ReportingDBContext : IdentityDbContext<ApplicationUser>
    {
        public ReportingDBContext() : base("ReportingDB") 
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ReportingDBContext, Configuration>());
        }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Project> Projects { get; set; }
        public DbSet<DomainModels.Task> Tasks { get; set; }
        public DbSet<TaskDone> TasksDone { get; set; }
        public DbSet<FinalComment> FinalComments { get; set; }

    }
}
