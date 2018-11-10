using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sms.Domain.Migrations
{
    public partial class AddedTeacerAndClassesMtoMRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasseses_Classes_ClassesId",
                table: "StudentClasseses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasseses_Students_StudentId",
                table: "StudentClasseses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClasseses",
                table: "StudentClasseses");

            migrationBuilder.RenameTable(
                name: "StudentClasseses",
                newName: "StudentClasses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasseses_StudentId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasseses_ClassesId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_ClassesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClasses",
                table: "StudentClasses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TeacherClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    ClassesId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherClasses_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherClasses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClasses_ClassesId",
                table: "TeacherClasses",
                column: "ClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClasses_EmployeeId",
                table: "TeacherClasses",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Classes_ClassesId",
                table: "StudentClasses",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Students_StudentId",
                table: "StudentClasses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Classes_ClassesId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Students_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropTable(
                name: "TeacherClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClasses",
                table: "StudentClasses");

            migrationBuilder.RenameTable(
                name: "StudentClasses",
                newName: "StudentClasseses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClasseses",
                newName: "IX_StudentClasseses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_ClassesId",
                table: "StudentClasseses",
                newName: "IX_StudentClasseses_ClassesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClasseses",
                table: "StudentClasseses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasseses_Classes_ClassesId",
                table: "StudentClasseses",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasseses_Students_StudentId",
                table: "StudentClasseses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
