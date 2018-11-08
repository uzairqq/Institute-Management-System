using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sms.Domain.Migrations
{
    public partial class AddedTrasportationAndLinkWithEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transportations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DriverContact = table.Column<string>(nullable: true),
                    Fare = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TransportationId",
                table: "Employees",
                column: "TransportationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Transportations_TransportationId",
                table: "Employees",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Transportations_TransportationId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Transportations");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TransportationId",
                table: "Employees");
        }
    }
}
