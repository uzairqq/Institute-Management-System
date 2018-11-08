﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sms.Domain;

namespace Sms.Domain.Migrations
{
    [DbContext(typeof(SmsDbContext))]
    [Migration("20181025162200_NewTransaction")]
    partial class NewTransaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Sms.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(1024);

                    b.Property<int>("Age");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<int>("EmergencyContact");

                    b.Property<string>("HomeNumber")
                        .HasMaxLength(20);

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("Lastname")
                        .HasMaxLength(100);

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Sms.Domain.Entities.Subjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("SubjectName");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Sms.Domain.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("LastName");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("SubjectId");

                    b.Property<int?>("SubjectsId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectsId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Sms.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("TransactionType");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Sms.Domain.Entities.TransactionDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnName");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<string>("TableId");

                    b.Property<string>("TableName");

                    b.Property<int?>("TransactionId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("Sms.Domain.Entities.TransactionProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnName");

                    b.Property<string>("ColumnNewValue");

                    b.Property<string>("ColumnOldValue");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsPrimaryKey");

                    b.Property<int>("LastUpdatedById");

                    b.Property<DateTime>("LastUpdatedOn");

                    b.Property<int>("TransactionDetailId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionDetailId");

                    b.ToTable("TransactionProperties");
                });

            modelBuilder.Entity("Sms.Domain.Entities.Teacher", b =>
                {
                    b.HasOne("Sms.Domain.Entities.Subjects", "Subjects")
                        .WithMany()
                        .HasForeignKey("SubjectsId");
                });

            modelBuilder.Entity("Sms.Domain.Entities.TransactionDetails", b =>
                {
                    b.HasOne("Sms.Domain.Entities.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("Sms.Domain.Entities.TransactionProperties", b =>
                {
                    b.HasOne("Sms.Domain.Entities.TransactionDetails", "TransactionDetail")
                        .WithMany("TransactionProperties")
                        .HasForeignKey("TransactionDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
