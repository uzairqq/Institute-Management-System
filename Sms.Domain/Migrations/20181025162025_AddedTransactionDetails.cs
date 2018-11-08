using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Sms.Domain.Migrations
{
    public partial class AddedTransactionDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionDetails",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ColumnNewValue",
                table: "TransactionDetails");

            migrationBuilder.DropColumn(
                name: "ColumnOldValue",
                table: "TransactionDetails");

            migrationBuilder.CreateTable(
                name: "TransactionProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    ColumnOldValue = table.Column<string>(nullable: true),
                    ColumnNewValue = table.Column<string>(nullable: true),
                    TransactionDetailId = table.Column<int>(nullable: false),
                    IsPrimaryKey = table.Column<bool>(nullable: false),
                    ColumnName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionProperties_TransactionDetails_TransactionDetailId",
                        column: x => x.TransactionDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionProperties_TransactionDetailId",
                table: "TransactionProperties",
                column: "TransactionDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionProperties");

            migrationBuilder.AddColumn<string>(
                name: "TransactionDetails",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnNewValue",
                table: "TransactionDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnOldValue",
                table: "TransactionDetails",
                nullable: true);
        }
    }
}
