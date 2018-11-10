using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Branch:BaseEntity
    {
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [StringLength(155)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Principal { get; set; }
    }
}
