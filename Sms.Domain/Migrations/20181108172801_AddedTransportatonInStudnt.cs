using Microsoft.EntityFrameworkCore.Migrations;

namespace Sms.Domain.Migrations
{
    public partial class AddedTransportatonInStudnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransportationId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TransportationId",
                table: "Students",
                column: "TransportationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Transportations_TransportationId",
                table: "Students",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Transportations_TransportationId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TransportationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TransportationId",
                table: "Students");
        }
    }
}
