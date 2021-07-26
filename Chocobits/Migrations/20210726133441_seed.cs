using Microsoft.EntityFrameworkCore.Migrations;

namespace Chocobits.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BannerLoc", "Description", "Name" },
                values: new object[] { 1, null, "Chocolate Bars, Chocolate Boxes, Pralines and Gifts.", "Chocolate Bars, Gift Boxes and Pralines" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BannerLoc", "Description", "Name" },
                values: new object[] { 2, null, "Cakes, Tarts and Pies", "Pies" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BannerLoc", "Description", "Name" },
                values: new object[] { 3, null, "Chocolate Ice Cream and Ice Creamsicles", "Ice Cream" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
