using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.DomainModels.Identity;

namespace Reporting.DomainModels
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaskID { get; set; }

        [MinLength(2, ErrorMessage = "Screen Name can't be less than 2 characters")]
        [MaxLength(50, ErrorMessage = "Screen Name can't exceed 50 characters")]
        public string Screen { get; set; }

        [MinLength(2, ErrorMessage = "Description can't be less than 2 characters")]
        [MaxLength(10000, ErrorMessage = "Description can't exceed 10000 characters")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Admin user ID can't be empty")]
        [ForeignKey("AdminUsers")]
        [Display(Name = "Admin User ID")]
        public string AdminUserID { get; set; }

        [Required(ErrorMessage = "User ID can't be empty.")]
        [ForeignKey("Users")]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Date of Task can't be empty.")]
        [Display(Name = "Date of Task")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateOfTask { get; set; }

        public string Attachment { get; set; }

        public Nullable<long> ProjectID { get; set; }


        public virtual Project Projects { get; set; }
        public virtual ApplicationUser AdminUsers { get; set; }
        public virtual ApplicationUser Users { get; set; }
    }
}
