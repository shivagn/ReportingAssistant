using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Reporting.DomainModels.ViewModels
{
    public class UserProfile
    {
        public string userName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
