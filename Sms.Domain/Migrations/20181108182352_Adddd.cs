using Microsoft.EntityFrameworkCore.Migrations;

namespace Sms.Domain.Migrations
{
    public partial class Adddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Transportations_TransportationId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "TransportationId",
                table: "Students",
                newName: "ClassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_TransportationId",
                table: "Students",
                newName: "IX_Students_ClassesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassesId",
                table: "Students",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassesId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ClassesId",
                table: "Students",
                newName: "TransportationId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassesId",
                table: "Students",
                newName: "IX_Students_TransportationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Transportations_TransportationId",
                table: "Students",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
