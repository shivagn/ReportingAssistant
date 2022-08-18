using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels.Identity;
using System.Security.Claims; 


namespace Reporting.RepositoryContracts
{
    public interface IAspNetUsersRepository
    {
        ApplicationUser FindUser(string userID);
        ApplicationUser FindUserByName(string userName);
        ApplicationUser FindUser(string userName, string Password); 
        bool Create(ApplicationUser user);
        void AddUserToRole(string userID , string roleName);
        ClaimsIdentity identyUser(ApplicationUser user, string AuthenticationType);
        bool userIsInRole(string userID, string roleName);
        List<ApplicationUser> usersInRole(string roleID);
        void Update(ApplicationUser user);

        List<ApplicationUser> GetAll();



    }
}
