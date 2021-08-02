using Microsoft.EntityFrameworkCore.Migrations;

namespace Chocobits.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerLoc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8)", precision: 8, nullable: false),
                    ImageLoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BannerLoc", "Description", "Name" },
                values: new object[] { 1, "category_chocolates.jpg", "Chocolate Bars, Chocolate Boxes, Pralines and Gifts.", "Chocolate Bars, Gift Boxes and Pralines" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BannerLoc", "Description", "Name" },
                values: new object[] { 2, "category_pies.jpg", "Cakes, Tarts and Pies", "Pies" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BannerLoc", "Description", "Name" },
                values: new object[] { 3, "category_icecream.jpg", "Chocolate Ice Cream and Ice Creamsicles", "Ice Cream" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageLoc", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "High Quality Milk Chocolate Bar 30% Cocoa 200g", "product_milkbar.jpg", "Milk Chocolate Bar", 4.35m },
                    { 2, 1, "Premium Cocoa Butter White Chocolate Bar 210g", "product_whitechocolate.jpg", "White Chocolate Bar", 5.20m },
                    { 3, 1, "6 60g Chocolate Ice Creamsicles with praline filling", "product_creamsicles.jpg", "Chocolate Ice Creamsicles", 5.20m },
                    { 4, 1, "Chocolate Cake with Raspberry Flavoring, 650g", "product_cake.jpg", "Chocolate and Raspberry Cake", 35.25m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
