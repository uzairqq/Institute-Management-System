using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Domain.Entities
{
   public class NewsBoard:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
