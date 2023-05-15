using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxPayers.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fistmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxPayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RNC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayer", x => x.Id);
                });

            //seed of tax payer
            migrationBuilder.InsertData(
                table: "TaxPayer",
                columns: new[] { "RNC", "Name", "Type", "Status", "CreatedDate", "UpdatedDate", "IsDeleted" },
                values: new object[] { "60207731799", "Jose Ramon", 1, 1, DateTime.Parse("2023-05-14 10:57:09.5444159"), DateTime.Parse("2023-05-14 14:46:26.9275106"), false });

            migrationBuilder.InsertData(
                table: "TaxPayer",
                columns: new[] { "RNC", "Name", "Type", "Status", "CreatedDate", "UpdatedDate", "IsDeleted" },
                values: new object[] { "40203250945", "Maria Perez", 2, 1, DateTime.Parse("2023-05-12 09:30:00.0000000"), DateTime.Parse("2023-05-13 15:20:10.1234567"), false });

            migrationBuilder.InsertData(
                table: "TaxPayer",
                columns: new[] { "RNC", "Name", "Type", "Status", "CreatedDate", "UpdatedDate", "IsDeleted" },
                values: new object[] { "10205040301", "Carlos Lopez", 1, 2, DateTime.Parse("2023-05-10 17:45:00.0000000"), DateTime.Parse("2023-05-14 09:10:20.9876543"), false });

            migrationBuilder.InsertData(
                table: "TaxPayer",
                columns: new[] { "RNC", "Name", "Type", "Status", "CreatedDate", "UpdatedDate", "IsDeleted" },
                values: new object[] { "50201304876", "Ana Silva", 2, 1, DateTime.Parse("2023-05-11 14:20:00.0000000"), DateTime.Parse("2023-05-14 16:30:05.5555555"), false });
            ///end seed

            migrationBuilder.CreateTable(
                name: "TaxReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxPayerId = table.Column<int>(type: "int", nullable: false),
                    NCF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxReceipt_TaxPayer_TaxPayerId",
                        column: x => x.TaxPayerId,
                        principalTable: "TaxPayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxReceipt_TaxPayerId",
                table: "TaxReceipt",
                column: "TaxPayerId");

            //seed of tax receipt
            migrationBuilder.InsertData(
                table: "TaxReceipt",
                columns: new[] { "TaxPayerId", "NCF", "Amount", "Tax", "CreatedDate", "UpdatedDate", "IsDeleted" },
                values: new object[] { 1, "F78347722599", 1500.50m, 270.09m, DateTime.Parse("2023-05-14 15:30:00"), null, false });

            migrationBuilder.InsertData(
                table: "TaxReceipt",
                columns: new[] { "TaxPayerId", "NCF", "Amount", "Tax", "CreatedDate", "UpdatedDate", "IsDeleted" },
                values: new object[] { 1, "G92417388471", 2500.75m, 450.14m, DateTime.Parse("2023-05-14 17:45:00"), null, false });

            migrationBuilder.InsertData(
                table: "TaxReceipt",
                columns: new[] { "TaxPayerId", "NCF", "Amount", "Tax", "CreatedDate", "UpdatedDate", "IsDeleted" },
                values: new object[] { 1, "H09345201001", 750.25m, 135.04m, DateTime.Parse("2023-05-15 10:00:00"), null, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxReceipt");

            migrationBuilder.DropTable(
                name: "TaxPayer");
        }
    }
}
