using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Reporting.DomainModels.Identity
{
    public class ApplicationUserStore:UserStore<ApplicationUser>
    {
        public ApplicationUserStore(IdentityDbContext dbContext) : base(dbContext)
        {

        }

        public ApplicationUserStore(DbContext context) : base(context)
        {
        }
    }
}
