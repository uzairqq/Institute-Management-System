using System;

namespace Sms.Domain.Entities
{
   public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedById { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
