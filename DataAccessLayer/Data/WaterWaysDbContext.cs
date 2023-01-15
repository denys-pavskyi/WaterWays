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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        private void SeedData(ModelBuilder modelBuilder)
        {

        }
    }
}
