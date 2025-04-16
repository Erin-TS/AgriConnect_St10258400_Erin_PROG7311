using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect_St10258400_Erin_PROG7311.Migrations
{
    /// <inheritdoc />
    public partial class IntiailCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userLastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    employeeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK_Employee_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    farmerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    farmerLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.farmerId);
                    table.ForeignKey(
                        name: "FK_Farmer_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Employee_userId",
                table: "Employee",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_userId",
                table: "Farmer",
                column: "userId",
                unique: true);

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

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
