using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect_St10258400_Erin_PROG7311.Migrations
{
    /// <inheritdoc />
    public partial class editFarmerPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "farmerRole",
                table: "Farmer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "farmerRole",
                table: "Farmer");
        }
    }
}
