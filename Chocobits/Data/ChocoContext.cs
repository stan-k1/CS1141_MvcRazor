using Chocobits.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chocobits.Data
{
    public class ChocoContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ChocoContext(DbContextOptions<ChocoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal").HasPrecision(8);
            modelBuilder.Entity<Product>().HasData(
                new Product 
                {
                    Id = 1,
                    Name = "Milk Chocolate Bar",
                    Price = 4.35m,
                    Description = "High Quality Milk Chocolate Bar 30% Cocoa 200g",
                    CategoryId = 1,
                    ImageLoc = "product_milkbar.jpg"
            },
                new Product()
                {
                    Id = 2,
                    Name = "White Chocolate Bar",
                    Price = 5.20m,
                    Description = "Premium Cocoa Butter White Chocolate Bar 210g",
                    CategoryId = 1, 
                    ImageLoc = "product_whitechocolate.jpg"
                },
                new Product()
                {
                    Id = 3,
                    Name = "Chocolate Ice Creamsicles",
                    Price = 5.20m,
                    Description = "6 60g Chocolate Ice Creamsicles with praline filling",
                    CategoryId = 3,
                    ImageLoc = "product_creamsicles.jpg"
                },
                new Product()
                {
                    Id = 4,
                    Name = "Chocolate and Raspberry Cake",
                    Price = 35.25m,
                    Description = "Chocolate Cake with Raspberry Flavoring, 650g",
                    CategoryId = 2,
                    ImageLoc = "product_cake.jpg"
                });

            modelBuilder.Entity<Category>().HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Chocolates and Pralines",
                    Description = "Premium Chocolate Bars, Chocolate Boxes and Pralines. Premium dark, milk and white chocolate. Gift boxes available.",
                    BannerLoc = "category_chocolates.jpg"
                },
                new Category
                {
                    Id = 2,
                    Name = "Pies",
                    Description = "Cakes, Tarts and Pies. High quality premium chocolate based deserts available in a handpicked collection of various flavors and fillings.",
                    BannerLoc = "category_pies.jpg"
                },
                new Category
                {
                    Id = 3,
                    Name = "Ice Cream",
                    Description = "Chocolate Ice Cream and Ice Creamsicles. High quality fresh ice cream based on our premium chocolate products.",
                    BannerLoc = "category_icecream.jpg"
                }
            );
        }
    }
}