using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect_St10258400_Erin_PROG7311.Migrations
{
    /// <inheritdoc />
    public partial class secondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    employeeLastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    employeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeePasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.employeeId);
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    farmerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    farmerFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    farmerLastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    farmerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    farmerPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    farmerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    farmerRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    farmerLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.farmerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productCategory = table.Column<int>(type: "int", nullable: false),
                    productDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    productionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    farmerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productID);
                    table.ForeignKey(
                        name: "FK_Product_Farmer_farmerId",
                        column: x => x.farmerId,
                        principalTable: "Farmer",
                        principalColumn: "farmerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_farmerId",
                table: "Product",
                column: "farmerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Farmer");
        }
    }
}
