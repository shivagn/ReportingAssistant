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
    public class FinalComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FinalCommentID { get; set; }

        [MinLength(2, ErrorMessage = "Screen name can't be less than 2 characters.")]
        [MaxLength(50, ErrorMessage = "Screen name can't exceed 50 characters.")]
        public string Screen { get; set; }

        [MinLength(2, ErrorMessage = "Description can't be less than 2 characters.")]
        [MaxLength(10000, ErrorMessage = "Description can't be more than 10000 characters.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Admin user ID can't be empty.")]
        [ForeignKey("AdminUsers")]
        [Display(Name = "Admin User ID")]
        public string AdminUserID { get; set; }

        
        [Required(ErrorMessage = "User ID can't be empty.")]
        [ForeignKey("Users")]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        
        [Required(ErrorMessage = "Date of Final Comment can't be empty.")]
        [Display(Name = "Date of Final Comment")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateOfFinalComment { get; set; }

        public string Attachment { get; set; }

        [Required]
        public Nullable<long> ProjectID { get; set; }
        
        
        
        public virtual ApplicationUser AdminUsers { get; set; }
        public virtual ApplicationUser Users { get; set; }
        public virtual Project Projects { get; set; }
    }
}
