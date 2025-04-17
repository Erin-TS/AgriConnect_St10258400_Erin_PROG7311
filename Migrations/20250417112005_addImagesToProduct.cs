using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect_St10258400_Erin_PROG7311.Migrations
{
    /// <inheritdoc />
    public partial class addImagesToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "productImage",
                table: "Product",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productImage",
                table: "Product");
        }
    }
}
