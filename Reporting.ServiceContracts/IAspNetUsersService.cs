using Reporting.DomainModels.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace Reporting.ServiceContracts
{
    public interface IAspNetUsersService
    {
        ApplicationUser FindUser(string userID);
        ApplicationUser FindUserByName(string userName);   
        ApplicationUser FindUser(string userName, string password);
        bool Create(ApplicationUser user);
        void AddUserToRole(string userID, string roleName);
        bool UserExist(string userName);
        ApplicationUser InitialUser(string userName);
        ClaimsIdentity identyUser(ApplicationUser user, string AuthenticationType);
        bool userIsInRole(string userID, string roleName);
        List<ApplicationUser> usersWithRole(string roleName);
        void UpdateUser(ApplicationUser User);
        List<ApplicationUser> GetAllUsers();

    }
}
