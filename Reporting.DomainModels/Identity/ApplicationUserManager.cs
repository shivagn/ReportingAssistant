using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Reporting.DomainModels.Identity
{
    public class ApplicationUserManager:UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {

        }
    }
}
