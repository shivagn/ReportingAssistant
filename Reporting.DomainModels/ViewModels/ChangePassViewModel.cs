using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Reporting.DomainModels.ViewModels
{
    public class ChangePassViewModel
    {
        public string Username { get; set; }

        
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }    

        
        [Required(ErrorMessage = "Password can't be blank")]
        [Display(Name ="New Password")]
        public string NewPassword { get; set; }

        
        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("NewPassword", ErrorMessage = "New Password and confirmed password do not match")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
