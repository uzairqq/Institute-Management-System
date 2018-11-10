using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Payment:BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string Title { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }

        public int Amount { get; set; }

        public int BillNumber { get; set; }

        public string Status { get; set; }

        public string FeePeriod { get; set; }

        public DateTime DateOfPayment { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClassId { get; set; }
        public Classes Classes { get; set; }
    }
}
