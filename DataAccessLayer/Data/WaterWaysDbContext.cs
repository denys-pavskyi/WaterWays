using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Data
{
    public class WaterWaysDbContext:DbContext
    {

        public WaterWaysDbContext(DbContextOptions<WaterWaysDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<WaterPoint> WaterPoints { get; set; }
        public DbSet<VerificationDocument> VerificationDocuments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
                .HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.WaterPoint).WithMany(x => x.Products).HasForeignKey(x => x.WaterPointId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasMany(x => x.OrderDetails).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);
            
           modelBuilder.Entity<RegisteredUser>()
                .HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RegisteredUser>()
                .HasMany(x => x.ShoppingCartItems).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.WaterPoint).WithMany(x => x.Reviews).HasForeignKey(x => x.WaterPointId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Review>()
                .HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

            
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(x => x.User).WithMany(x => x.ShoppingCartItems).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VerificationDocument>()
                .HasOne(x => x.WaterPoint).WithOne(x => x.VerificationDocument).OnDelete(DeleteBehavior.NoAction);
           

            modelBuilder.Entity<WaterPoint>()
                .HasOne(x => x.VerificationDocument).WithOne(x => x.WaterPoint).OnDelete(DeleteBehavior.Cascade);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {

        }
    }
}
