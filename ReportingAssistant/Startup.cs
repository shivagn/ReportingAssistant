using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;
using Reporting.ServiceLayer;
using Reporting.ServiceContracts;
using Reporting.DomainModels.Identity;
using Reporting.RepositoryContracts;
using Reporting.RepositoryLayer;

[assembly: OwinStartup(typeof(ReportingAssistant.Startup))]

namespace ReportingAssistant
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            this.CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            IAspNetRolesRepository r = new AspNetRoleRepository();
            IAspNetUsersRepository u = new AspNetUserRepository();
            AspNetRoleService repRole = new AspNetRoleService(r);
            IAspNetUsersService repUser = new AspNetUserService(u, r);

            // Create Admin Role
            if (!repRole.RoleExistsByName("Admin"))
            {
                repRole.AddRole("Admin");
            }

            //Create User Role
            if (!repRole.RoleExistsByName("User"))
            {
                repRole.AddRole("User");
            }



            //Create Users

            // first User
            if (!repUser.UserExist("nuzhath"))
            {
                ApplicationUser user = repUser.InitialUser("nuzhath");
                
                bool chkUser = repUser.Create(user);

                if (chkUser)
                {
                    repUser.AddUserToRole(user.Id, "User");
                }
            }


            // second User
            if (!repUser.UserExist("nazareen"))
            {
                ApplicationUser user = repUser.InitialUser("nazareen");

                bool chkUser = repUser.Create(user);

                if (chkUser)
                {
                    repUser.AddUserToRole(user.Id, "User");
                }
            }

            // third User & first Admin
            if (!repUser.UserExist("harsha"))
            {
                ApplicationUser user = repUser.InitialUser("harsha");

                bool chkUser = repUser.Create(user);

                if (chkUser)
                {
                    repUser.AddUserToRole(user.Id, "User");
                    repUser.AddUserToRole(user.Id, "Admin");
                }
            }

            // second Admin
            if (!repUser.UserExist("shylender"))
            {
                ApplicationUser user = repUser.InitialUser("shylender");

                bool chkUser = repUser.Create(user);

                if (chkUser)
                {
                    repUser.AddUserToRole(user.Id, "Admin");
                }
            }

            // second Admin
            if (!repUser.UserExist("harika"))
            {
                ApplicationUser user = repUser.InitialUser("harika");

                bool chkUser = repUser.Create(user);

                if (chkUser)
                {
                    repUser.AddUserToRole(user.Id, "Admin");
                }
            }


        }
    }
}
