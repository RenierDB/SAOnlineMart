using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
        public DbSet<OrderProduct> OrderProducts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>().HasMany(x => x.Products)
            .WithMany(x => x.Orders)
            .UsingEntity<OrderProduct>(
                x => x.HasOne(x => x.Product)
                .WithMany().HasForeignKey(x => x.ProductId),
                x => x.HasOne(x => x.Order)
               .WithMany().HasForeignKey(x => x.OrderId));


            base.OnModelCreating(modelBuilder);

            string adminUserId = "22ffc532-008e-492d-92b1-e867501f2d54";
            string adminPassword = "Admin@123";

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
                    PasswordHash = hasher.HashPassword(null, adminPassword),
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
                new Product { Id = 1, Name = "Samsung 870 QVO 4 TB SATA Internal Solid State Drive", Description = "Sequential read/write speeds up to 560/530 mb/s respectively; performance varies based on system hardware configuration", Price = 7200.0m, ImageUrl = "https://m.media-amazon.com/images/I/81XOtXza9NS._AC_SX679_.jpg" },
                new Product { Id = 2, Name = "Crucial P3 Plus NVME 4TB M.2 Internal Solid State Drive", Description = "Helps to make your system start in seconds and load files instantly", Price = 6620.0m, ImageUrl = "https://m.media-amazon.com/images/I/51xZaoS+Q1L._AC_SX679_.jpg" },
                new Product { Id = 3, Name = "Cudy AX5400 Tri-Band Wi-Fi 6 PCI Express Adapter", Description = "Tri-Band support with speeds of 2402Mbps on both 5GHz and 6GHz bands and 574Mbps on the 2.4GHz band", Price = 609.0m, ImageUrl = "https://m.media-amazon.com/images/I/61GNasmfP1L._AC_SX679_.jpg" },
                new Product { Id = 4, Name = "Apple 2022 MacBook Air laptop with M2 chip", Description = "M2 chip for incredible performance", Price = 19980.0m, ImageUrl = "https://m.media-amazon.com/images/I/51xmHUvAvkL._AC_.jpg" },
                new Product { Id = 5, Name = "Crucial DDR4 3200MHz SODIMM Notebook Memory, 16GB", Description = "Higher level of reliability and 100 percent tested", Price = 1600.0m, ImageUrl = "https://m.media-amazon.com/images/I/71oz85Vv6mL._AC_SX522_.jpg" },
                new Product { Id = 6, Name = "Club 3D HDMI KVM Switch for 4K 60Hz Dual HDMI", Description = "Allows switching between two HDMI sources with a single display, keyboard and mouse", Price = 60.0m, ImageUrl = "https://m.media-amazon.com/images/I/61J+rekNKvL._SX522_.jpg" },
                new Product { Id = 7, Name = "Western Digital Portable External Hard Drive", Description = "Built-in 256-bit AES hardware encryption with password protection", Price = 1490.0m, ImageUrl = "https://m.media-amazon.com/images/I/51h4xi-KQRL._AC_SX679_.jpg" }
            );
        }
    }
}
