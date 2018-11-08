using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Transportation:BaseEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string DriverContact { get; set; }
        public int Fare { get; set; }
    }
}
