using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;

namespace Sms.Domain
{
   public class SmsDbContext:DbContext
    {
        public SmsDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
