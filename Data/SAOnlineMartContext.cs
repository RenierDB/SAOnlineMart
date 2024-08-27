using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SAOnlineMart.Models;

namespace SAOnlineMart.Data
{
    public class SAOnlineMartContext : DbContext
    {
        public SAOnlineMartContext(DbContextOptions<SAOnlineMartContext> options)
            : base(options)
        {
        }

        public DbSet<SAOnlineMart.Models.Product> Product { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product1", Description = "Description1", Price = 10.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 2, Name = "Product2", Description = "Description2", Price = 20.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 3, Name = "Product3", Description = "Description3", Price = 30.0m, ImageUrl = "https://placehold.co/800x800" }
            );
        }
    }
}
