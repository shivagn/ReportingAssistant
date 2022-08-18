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
    public class TaskDone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaskDoneID { get; set; }

        [MinLength(2, ErrorMessage = "Screen Name can't be less than 2 characters.")]
        [MaxLength(50, ErrorMessage = "Screen Name can't exceed 50 characters.")]        
        public string Screen { get; set; }

        [MinLength(2, ErrorMessage = "Description can't be less than 2 characters.")]
        [MaxLength(10000, ErrorMessage = "Description can't exceed 10000 characters.")]
        public string Description { get; set; }

        
        [Required(ErrorMessage = "User ID should be provided")]
        [ForeignKey("Users")]
        [Display(Name = "User ID")]
        public string UserID { get; set; }


        [Required(ErrorMessage = "Date of Task Done can't be empty.")]
        [Display(Name = "Date of Task Done")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateOfTaskDone { get; set; }

        public string Attachment { get; set; }

        [Required]
        public Nullable<long> ProjectID { get; set; }   



        public virtual ApplicationUser Users { get; set; }
        public virtual Project Projects { get; set; }

    }
}
