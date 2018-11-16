using Microsoft.EntityFrameworkCore.Migrations;

namespace Sms.Domain.Migrations
{
    public partial class ChangesInStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RollNoId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Students",
                newName: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1024,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "Students",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1024);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmergencyContact",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Students",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RollNoId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Students",
                nullable: true);
        }
    }
}
