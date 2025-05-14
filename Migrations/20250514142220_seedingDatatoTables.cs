using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgriConnect_St10258400_Erin_PROG7311.Migrations
{
    /// <inheritdoc />
    public partial class seedingDatatoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "employeeId", "employeeEmail", "employeeFirstName", "employeeLastName", "employeeNumber", "employeePasswordHash" },
                values: new object[,]
                {
                    { 1, "e.s@gmail.com", "Erin", "Steenveld", "1234567890", "AQAAAAIAAYagAAAAEAtucICMr/9Qo7oY64ZKjuDNQl4o4IEKTGLnIg2me6gWsT/igV3gX74Rq5fCfXf+tw==" },
                    { 2, "c.f@gmail.com", "Clive", "Frankland", "0987654321", "AQAAAAIAAYagAAAAEJsmEhWsXodkJ0v9yjYctFqboVA3gwmODW59YFnf2fXa9Wz2mE1CUJigmXMZZGxfxw==" }
                });

            migrationBuilder.InsertData(
                table: "Farmer",
                columns: new[] { "farmerId", "farmerEmail", "farmerFirstName", "farmerLastName", "farmerLocation", "farmerPassword", "farmerPasswordHash", "farmerRole" },
                values: new object[,]
                {
                    { 1, "j.m@gmail.com", "Jack", "Mcdonald", "Paarl", "Pass1234!", "AQAAAAIAAYagAAAAEANU33h/MGee9PzXT11T3ttuLMaRyucNSwTVig0eSlovR5RbKRsbc7j7GQvsydQjKA==", "Farmer" },
                    { 2, "p.l@gmail.com", "Penny", "Leaf", "Cape Town", "Pass1234!", "AQAAAAIAAYagAAAAEANU33h/MGee9PzXT11T3ttuLMaRyucNSwTVig0eSlovR5RbKRsbc7j7GQvsydQjKA==", "Farmer" },
                    { 3, "m.v@gmail.com", "Max", "Verstappen", "Stenllenbosch", "Pass1234!", "AQAAAAIAAYagAAAAEANU33h/MGee9PzXT11T3ttuLMaRyucNSwTVig0eSlovR5RbKRsbc7j7GQvsydQjKA==", "Farmer" },
                    { 4, "l.b@gmail.com", "Lilly", "Brown", "Onrus", "Pass1234!", "AQAAAAIAAYagAAAAEANU33h/MGee9PzXT11T3ttuLMaRyucNSwTVig0eSlovR5RbKRsbc7j7GQvsydQjKA==", "Farmer" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productID", "farmerId", "productCategory", "productDescription", "productName", "productionDate" },
                values: new object[,]
                {
                    { 1, 1, 1, "Freshly harvested potatoes", "Potatoes", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, "Freshly harvested  orange carrorts", "Carrots", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 1, "Freshly harvested baby radish", "Radish", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 5, "Whole Free range chickens", "Chicken", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, 7, "Free range eggs", "Brown Eggs", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, 0, "Big red gala apples", "Apples", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, 0, "Freshly harvested bananas", "Bananas", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, 0, "Freshly harvested grapes", "Grapes", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 4, 0, "Freshly harvested peaches", "Peaches", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, 11, "large leaf parsely", "Parsely", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, 11, "Freshly harvested rosemary", "Rosemary", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 4, 11, "Freshly harvested thyme", "Thyme", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 3, 3, "Pasurised  cow milk", "Jersey Milk", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 4, 3, "Pasurised goats milk", "Goats Milk", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, 3, " Long fermented brie cheese", "Brie Cheese", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 4, 7, "White chicken free range eggs", "White eggs free range", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 2, 4, "Free range bacon", "Bacon", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 4, 4, "Free range beef", "Beef steaks", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 3, 2, "finley ground rye flour", "Rye Flour", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 4, 2, "finley ground wheat flour", "Wheat Flour", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 4, 2, "finley ground oats", "Oats", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 2, 10, "Raw pumkin seeds", "Pumkin seeds", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 3, 10, "Raw sunflower seeds", "Sunflower seeds", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "employeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "employeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Farmer",
                keyColumn: "farmerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Farmer",
                keyColumn: "farmerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Farmer",
                keyColumn: "farmerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Farmer",
                keyColumn: "farmerId",
                keyValue: 4);
        }
    }
}
