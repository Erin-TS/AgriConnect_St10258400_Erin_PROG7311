using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect_St10258400_Erin_PROG7311.Migrations
{
    /// <inheritdoc />
    public partial class EditEMployeeModelFIelds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User_userId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Farmer_User_userId",
                table: "Farmer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Farmer_userId",
                table: "Farmer");

            migrationBuilder.DropIndex(
                name: "IX_Employee_userId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "employeeType",
                table: "Employee",
                newName: "employeeFirstName");

            migrationBuilder.AddColumn<string>(
                name: "farmerEmail",
                table: "Farmer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "farmerFirstName",
                table: "Farmer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "farmerLastName",
                table: "Farmer",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "farmerPasswordHash",
                table: "Farmer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "employeeNumber",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "employeeEmail",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "employeeLastName",
                table: "Employee",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "employeePasswordHash",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "farmerEmail",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "farmerFirstName",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "farmerLastName",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "farmerPasswordHash",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "employeeEmail",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "employeeLastName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "employeePasswordHash",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "employeeFirstName",
                table: "Employee",
                newName: "employeeType");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Farmer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "employeeNumber",
                table: "Employee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userLastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    userPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_userId",
                table: "Farmer",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_userId",
                table: "Employee",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User_userId",
                table: "Employee",
                column: "userId",
                principalTable: "User",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Farmer_User_userId",
                table: "Farmer",
                column: "userId",
                principalTable: "User",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
