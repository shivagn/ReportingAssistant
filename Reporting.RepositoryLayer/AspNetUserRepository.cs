using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels.Identity;
using Reporting.RepositoryContracts;
using Reporting.DataLayer;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Reporting.RepositoryLayer
{
    public class AspNetUserRepository : IAspNetUsersRepository
    {
        ReportingDBContext dbContext;
        ApplicationUserStore appUserStore;
        ApplicationUserManager userManager;
        public AspNetUserRepository()
        {
            this.dbContext = new ReportingDBContext();
            this.appUserStore = new ApplicationUserStore(dbContext);
            this.userManager = new ApplicationUserManager(appUserStore);
        }



        public void AddUserToRole(string userID, string roleName)
        {
            userManager.AddToRole(userID, roleName);
        }

        public bool Create(ApplicationUser user)
        {
            IdentityResult result = userManager.Create(user);            
            return result.Succeeded;
        }

        public ApplicationUser FindUser(string userID)
        {
            ApplicationUser user = dbContext.Users.FirstOrDefault(temp => temp.Id == userID);
            return user;
        }

        public ApplicationUser FindUserByName(string userName)
        {
            ApplicationUser user = userManager.FindByNameAsync(userName).Result;
            return user;
        }

        public ApplicationUser FindUser(string userName, string password)
        {
            ApplicationUser user = userManager.Find(userName, password);
            return user;
        }

        public ClaimsIdentity identyUser(ApplicationUser user, string AuthenticationType)
        {
            ClaimsIdentity userIdentity = userManager.CreateIdentity(user, AuthenticationType);
            return userIdentity;
        }

        public bool userIsInRole(string userID, string roleName)
        {
            bool result = userManager.IsInRole(userID, roleName);
            return result;
        }

        public List<ApplicationUser> usersInRole(string roleID)
        {
            List<ApplicationUser> users =  userManager.Users.Where(temp=>temp.Roles.Any(s => s.RoleId == roleID)).ToList();
            return users;
        }


        void IAspNetUsersRepository.Update(ApplicationUser user)
        {
            userManager.Update(user);
        }

        public List<ApplicationUser> GetAll()
        {
           List<ApplicationUser> allUsers = userManager.Users.ToList();
            return allUsers;
        }
    }
}
