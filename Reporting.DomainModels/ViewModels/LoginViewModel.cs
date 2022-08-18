using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reporting.DomainModels.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username Can't be blank")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password Can't be blank")]
        public string Password { get; set; }
    }
}
