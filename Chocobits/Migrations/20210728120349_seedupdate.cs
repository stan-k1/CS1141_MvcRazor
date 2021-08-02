using Microsoft.EntityFrameworkCore.Migrations;

namespace Chocobits.Migrations
{
    public partial class seedupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Premium Chocolate Bars, Chocolate Boxes and Pralines. Premium dark, milk and white chocolate. Gift boxes available.", "Chocolates and Pralines" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Cakes, Tarts and Pies. High quality chocolate based deserts available with various flavors and fillings.");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Chocolate Ice Cream and Ice Creamsicles. High quality fresh ice cream based on our premium chocolate products.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Chocolate Bars, Chocolate Boxes, Pralines and Gifts.", "Chocolate Bars, Gift Boxes and Pralines" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Cakes, Tarts and Pies");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Chocolate Ice Cream and Ice Creamsicles");
        }
    }
}
