using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Classes:BaseEntity
    {

        [StringLength(30)]
        [Required]
        public string Class { get; set; }

        public string Standard { get; set; }
        public string Section { get; set; }

        
    }
}
