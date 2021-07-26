using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS1141_MvcRazor.Domain;
using Microsoft.EntityFrameworkCore;

namespace CS1141_MvcRazor.Data
{
    public class ChocoContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ChocoContext(DbContextOptions<ChocoContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
