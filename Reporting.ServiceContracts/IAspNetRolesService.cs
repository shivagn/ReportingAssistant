using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.ServiceContracts
{
    public interface IAspNetRolesService
    {
        bool RoleExistsByName(string roleName);
        void AddRole(string roleName);
        string GetRoleID(string roleName);

    }
}
