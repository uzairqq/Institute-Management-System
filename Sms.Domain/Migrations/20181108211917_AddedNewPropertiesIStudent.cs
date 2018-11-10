using Microsoft.EntityFrameworkCore.Migrations;

namespace Sms.Domain.Migrations
{
    public partial class AddedNewPropertiesIStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Classes_ClassesId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Students_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClasses_Classes_ClassesId",
                table: "TeacherClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClasses_Employees_EmployeeId",
                table: "TeacherClasses");

            migrationBuilder.DropIndex(
                name: "IX_TeacherClasses_ClassesId",
                table: "TeacherClasses");

            migrationBuilder.DropIndex(
                name: "IX_TeacherClasses_EmployeeId",
                table: "TeacherClasses");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_ClassesId",
                table: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "ClassesId",
                table: "TeacherClasses");

            migrationBuilder.DropColumn(
                name: "ClassesId",
                table: "StudentClasses");

            migrationBuilder.AddColumn<int>(
                name: "StudentClassesId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherClassesId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Standard",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentClassesId",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherClassesId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentClassesId",
                table: "Students",
                column: "StudentClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeacherClassesId",
                table: "Employees",
                column: "TeacherClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_StudentClassesId",
                table: "Classes",
                column: "StudentClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeacherClassesId",
                table: "Classes",
                column: "TeacherClassesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_StudentClasses_StudentClassesId",
                table: "Classes",
                column: "StudentClassesId",
                principalTable: "StudentClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_TeacherClasses_TeacherClassesId",
                table: "Classes",
                column: "TeacherClassesId",
                principalTable: "TeacherClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_TeacherClasses_TeacherClassesId",
                table: "Employees",
                column: "TeacherClassesId",
                principalTable: "TeacherClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentClasses_StudentClassesId",
                table: "Students",
                column: "StudentClassesId",
                principalTable: "StudentClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_StudentClasses_StudentClassesId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_TeacherClasses_TeacherClassesId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_TeacherClasses_TeacherClassesId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentClasses_StudentClassesId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentClassesId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TeacherClassesId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Classes_StudentClassesId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TeacherClassesId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "StudentClassesId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TeacherClassesId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Standard",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "StudentClassesId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "TeacherClassesId",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "ClassesId",
                table: "TeacherClasses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassesId",
                table: "StudentClasses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClasses_ClassesId",
                table: "TeacherClasses",
                column: "ClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClasses_EmployeeId",
                table: "TeacherClasses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_ClassesId",
                table: "StudentClasses",
                column: "ClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClasses",
                column: "StudentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClasses_Classes_ClassesId",
                table: "TeacherClasses",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClasses_Employees_EmployeeId",
                table: "TeacherClasses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
