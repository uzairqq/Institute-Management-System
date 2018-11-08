using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Exam:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
