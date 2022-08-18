using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Reporting.RepositoryContracts;
using Reporting.DataLayer;

namespace Reporting.RepositoryLayer
{
    public class AspNetRoleRepository : IAspNetRolesRepository
    {       
        RoleManager<IdentityRole> roleManager;
        ReportingDBContext dbContext;   
        public AspNetRoleRepository()
        {
            dbContext = new ReportingDBContext();
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
        }
        public bool checkExistence(string roleName)
        {
            bool result = roleManager.RoleExists(roleName);
            return result;
        }

        public void create(string roleName)
        {
            var role = new IdentityRole();
            role.Name = roleName;
            roleManager.Create(role);
        }


        string IAspNetRolesRepository.FindRole(string roleName)
        {
            string role = roleManager.FindByName(roleName).Id;
            return role;
        }
    }
}
