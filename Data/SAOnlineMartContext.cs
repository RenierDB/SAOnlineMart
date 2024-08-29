using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAOnlineMart.Models;
using System.Security.Claims;

namespace SAOnlineMart.Data
{
    public class SAOnlineMartContext : IdentityDbContext<ApplicationUser>
    {
        public SAOnlineMartContext(DbContextOptions<SAOnlineMartContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<ShippingAddress> ShippingAddress { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string adminUserId = "22ffc532-008e-492d-92b1-e867501f2d54";

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "22ffc532-008e-492d-92b1-e867501f2d54",
                    UserName = "admin@saonlinemart.com",
                    NormalizedUserName = "ADMIN@SAONLINEMART.COM",
                    Email = "admin@saonlinemart.com",
                    NormalizedEmail = "ADMIN@SAONLINEMART.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    SecurityStamp = string.Empty,
                    FirstName = "Admin",
                    LastName = "User"
                }
            );

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
            new IdentityUserClaim<string>
            {
                Id = 1,
                UserId = "22ffc532-008e-492d-92b1-e867501f2d54",
                ClaimType = "Permission",
                ClaimValue = "CanAccessAdminPage"
            }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product1", Description = "Description1", Price = 10.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 2, Name = "Product2", Description = "Description2", Price = 20.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 3, Name = "Product3", Description = "Description3", Price = 30.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 4, Name = "Product4", Description = "Description4", Price = 40.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 5, Name = "Product5", Description = "Description5", Price = 50.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 6, Name = "Product6", Description = "Description6", Price = 60.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 7, Name = "Product7", Description = "Description7", Price = 70.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 8, Name = "Product8", Description = "Description8", Price = 80.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 9, Name = "Product9", Description = "Description9", Price = 90.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 10, Name = "Product10", Description = "Description10", Price = 100.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 11, Name = "Product11", Description = "Description11", Price = 110.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 12, Name = "Product12", Description = "Description12", Price = 120.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 13, Name = "Product13", Description = "Description13", Price = 130.0m, ImageUrl = "https://placehold.co/800x800" }
            );
        }
    }
}
