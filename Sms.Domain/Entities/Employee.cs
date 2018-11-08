using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sms.Domain.Entities
{
   public class Employee:BaseEntity
    {

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }


        public string Email { get; set; }

        public int Age { get; set; }


        [StringLength(12)]
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        [StringLength(1024)]
        public string Address { get; set; }//yahan pr address ka alg table banana hay .aur link krna hay ise ko

        [StringLength(40)]
        public string PhoneNumber { get; set; }

        [StringLength(40)]
        public string MobileNumber { get; set; }

        public string Qualifications { get; set; }
       
        [StringLength(40)]
        public string NicNumber { get; set; }

        public string Photo { get; set; }

        public int EmployeeTypeId { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public int TransportationId { get; set; }
        public Transportation Transportation { get; set; }

        //public int SubjectId { get; set; }
        //public Subjects Subjects { get; set; }
    }
}
