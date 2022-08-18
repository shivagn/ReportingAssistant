using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Reporting.RepositoryContracts
{
    public interface IAspNetRolesRepository
    {
        bool checkExistence(string roleName);
        void create(string roleName);
        string FindRole(string roleName);

    }
}
