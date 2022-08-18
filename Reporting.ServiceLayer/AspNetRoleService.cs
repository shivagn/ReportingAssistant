using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.ServiceContracts;
using Reporting.RepositoryContracts;

namespace Reporting.ServiceLayer
{
    public class AspNetRoleService : IAspNetRolesService
    {
        IAspNetRolesRepository roleRep;
        public AspNetRoleService(IAspNetRolesRepository r)
        {
            this.roleRep = r;
        }

        public void AddRole(string roleName)
        {
            roleRep.create(roleName);
        }

        public string GetRoleID(string roleName)
        {
           string result = roleRep.FindRole(roleName);
            return result;
        }

        public bool RoleExistsByName(string roleName)
        {
            bool result = roleRep.checkExistence(roleName);
            return result;
        }
    }
}
