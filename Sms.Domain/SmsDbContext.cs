﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sms.Domain.Entities;

namespace Sms.Domain
{
    public class SmsDbContext : DbContext
    {
        public SmsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AttendanceType> AttendanceTypes { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Assignements> Assignments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<NewsBoard> NewsBoards { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<StudentClasses> StudentClasses { get; set; }
        public DbSet<TeacherClasses> TeacherClasses { get; set; }
        public DbSet<StudentTeacher> StudentTeachers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public Address Address { get; set; }




    }
}
