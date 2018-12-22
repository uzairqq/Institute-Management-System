using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sms.Domain.Entities
{
   public class EmployeeType:BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Type { get; set; }
        //Management
        //Teachers
        //Janitors
    }
}
