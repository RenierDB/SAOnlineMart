using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAOnlineMart.Models;

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

            string adminRoleId = "22ffc532-008e-492d-92b1-e867501f2d54";
            string adminUserId = "22ffc532-008e-492d-92b1-e867501f2d54";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = adminUserId,
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

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product1", Description = "Description1", Price = 10.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 2, Name = "Product2", Description = "Description2", Price = 20.0m, ImageUrl = "https://placehold.co/800x800" },
                new Product { Id = 3, Name = "Product3", Description = "Description3", Price = 30.0m, ImageUrl = "https://placehold.co/800x800" }
            );
        }
    }
}
