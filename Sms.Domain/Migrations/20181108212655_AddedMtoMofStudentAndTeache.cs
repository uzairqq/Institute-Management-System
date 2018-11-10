using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sms.Domain.Migrations
{
    public partial class AddedMtoMofStudentAndTeache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentTeacherId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentTeacherId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeachers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentTeacherId",
                table: "Students",
                column: "StudentTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StudentTeacherId",
                table: "Employees",
                column: "StudentTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_StudentTeachers_StudentTeacherId",
                table: "Employees",
                column: "StudentTeacherId",
                principalTable: "StudentTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentTeachers_StudentTeacherId",
                table: "Students",
                column: "StudentTeacherId",
                principalTable: "StudentTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_StudentTeachers_StudentTeacherId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentTeachers_StudentTeacherId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudentTeachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentTeacherId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Employees_StudentTeacherId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StudentTeacherId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentTeacherId",
                table: "Employees");
        }
    }
}
