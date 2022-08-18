using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.DomainModels
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CategoryID { get; set; }


        [Required(ErrorMessage = "Please Enter Category Name")]
        [Display(Name = "Category Name")]
        [RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage = "Please insert a valid Name")]
        public string CategoryName { get; set; }
    }
}
