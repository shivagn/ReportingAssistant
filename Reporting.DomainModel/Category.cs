using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reporting.DomainModel
{
    internal class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CategoryID { get; set; }


        [Required]
        [Display(Name = "Category Name")]
        [RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage = "Please insert a valid Name")]
        [Index("Ix_CategoryName", Order = 1 , IsUnique = true)]
        public string CategoryName { get; set; }
    }
}
