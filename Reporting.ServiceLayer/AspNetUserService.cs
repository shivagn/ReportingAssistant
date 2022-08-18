using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.ServiceContracts;
using Reporting.DomainModels;
using Reporting.DomainModels.Identity;
using Reporting.RepositoryContracts;
using System.Web.Helpers;
using System.Security.Claims;

namespace Reporting.ServiceLayer
{
    public class AspNetUserService : IAspNetUsersService
    {
        IAspNetUsersRepository repUser;
        IAspNetRolesRepository repRole;
        public AspNetUserService(IAspNetUsersRepository repUser, IAspNetRolesRepository repRole)
        {
            this.repUser = repUser;
            this.repRole = repRole;
        }

        public void AddUserToRole(string userID, string roleName)
        {
            bool chkRole = repRole.checkExistence(roleName);
            if (chkRole)
            {
                repUser.AddUserToRole(userID, roleName);
            }
        }

        public bool Create(ApplicationUser user)
        {
            bool chek = repUser.Create(user);
            return chek;
           
        }

        public ApplicationUser InitialUser(string userName)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = userName;
            user.Email = userName + @"@test.com";
            string pass = userName + "123";
            user.PasswordHash= Crypto.HashPassword(pass);
            return user;

        }

        public ApplicationUser FindUser(string userID)
        {
           ApplicationUser user = repUser.FindUser(userID);
           return user;
        }

        public ApplicationUser FindUser(string userName, string password)
        {
            ApplicationUser user = repUser.FindUser(userName, password);
            return user;
        }

        public ApplicationUser FindUserByName(string userName)
        {
           ApplicationUser user = repUser.FindUserByName(userName);
           return user;
        }

        public bool UserExist(string userName)
        {
           bool result = FindUserByName(userName) != null ? true : false;
            return result;
        }

        public ClaimsIdentity identyUser(ApplicationUser user, string AuthenticationType)
        {
           var result = repUser.identyUser(user, AuthenticationType);   
            return result;
        }

        public bool userIsInRole(string userID, string roleName)
        {
           bool result = repUser.userIsInRole(userID, roleName);
            return result;
        }

        List<ApplicationUser> IAspNetUsersService.usersWithRole(string roleName)
        {
            string roleID = repRole.FindRole(roleName);
            List<ApplicationUser> users = repUser.usersInRole(roleID);
            return users;
        }

        public void UpdateUser(ApplicationUser User)
        {
            repUser.Update(User);
        }

        List<ApplicationUser> IAspNetUsersService.GetAllUsers()
        {
            return repUser.GetAll();
        }
    }
}
