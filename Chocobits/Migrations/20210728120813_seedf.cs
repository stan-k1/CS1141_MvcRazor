using Microsoft.EntityFrameworkCore.Migrations;

namespace Chocobits.Migrations
{
    public partial class seedf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Cakes, Tarts and Pies. High quality premium chocolate based deserts available in a handpicked collection of various flavors and fillings.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Cakes, Tarts and Pies. Chocolate based deserts available with various flavors anf fillings.");
        }
    }
}
