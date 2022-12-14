using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reporting.DomainModel
{
    internal class TasksDone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaskDoneID { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Screen { get; set; }

        [MinLength(2)]
        [MaxLength(10000)]
        public string Description { get; set; }

        [Required]
        public System.DateTime DateOfTaskDone { get; set; }

        public string Attachment;

        [Required]
        public Nullable<long> ProjectID;
        public virtual Project Project { get; set; }
    }
}
