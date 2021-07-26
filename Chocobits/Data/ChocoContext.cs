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
            modelBuilder.Entity<Category>().HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Chocolate Bars, Gift Boxes and Pralines",
                    Description = "Chocolate Bars, Chocolate Boxes, Pralines and Gifts."
                },
                new Category
                {
                    Id = 2,
                    Name = "Pies",
                    Description = "Cakes, Tarts and Pies"
                },
                new Category
                {
                    Id = 3,
                    Name = "Ice Cream",
                    Description = "Chocolate Ice Cream and Ice Creamsicles"
                }
            );
        }
    }
}