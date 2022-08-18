using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.DomainModels
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProjectID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [RegularExpression(@"^[A-Za-z0-9 ]*$", ErrorMessage = "Please insert a valid Name")]
        //[Index("Ix_ProjectName", Order = 1, IsUnique = true)]
        public string ProjectName { get; set; }
        public Nullable<System.DateTime> DateOfStart { get; set; }

        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }       

        [Required]
        public Nullable<long> CategoryID { get; set; }
        public string Photo { get; set; }


        public virtual Category Category { get; set; }
    }
}
