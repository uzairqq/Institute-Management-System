using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Assignements:BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        
        [StringLength(1024)]
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public string File { get; set; }

        public int SubjectId { get; set; }

        public int ClassId { get; set; }
        public Classes Class { get; set; }
    }
}
