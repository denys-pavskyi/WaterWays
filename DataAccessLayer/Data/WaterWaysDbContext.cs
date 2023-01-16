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

            SeedData(modelBuilder);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisteredUser>().HasData(
                    new RegisteredUser { 
                        Id = 1,
                        FirstName = "User1",
                        LastName = "111",
                        UserName = "user1",
                        Password = "password1",
                        Role = RegisteredUserRole.RegisteredUser,
                        Email = "user1@gmai.com",
                        Phone = "(068)-111-11-11",
                        Address = "address1",

                    },
                    new RegisteredUser
                    {
                        Id = 2,
                        FirstName = "Representative2",
                        LastName = "222",
                        UserName = "user2",
                        Password = "password2",
                        Role = RegisteredUserRole.WaterPointRepresentative,
                        Email = "user2@gmai.com",
                        Phone = "(068)-222-22-22",
                        Address = "address2",

                    },
                    new RegisteredUser
                    {
                        Id = 3,
                        FirstName = "Representative3",
                        LastName = "333",
                        UserName = "user3",
                        Password = "password3",
                        Role = RegisteredUserRole.WaterPointRepresentative,
                        Email = "user3@gmai.com",
                        Phone = "(068)-333-33-33",
                        Address = "address3",

                    },
                    new RegisteredUser
                    {
                        Id = 4,
                        FirstName = "Admin4",
                        LastName = "444",
                        UserName = "user4",
                        Password = "password4",
                        Role = RegisteredUserRole.Admin,
                        Email = "user4@gmai.com",
                        Phone = "(068)-444-44-44",
                        Address = "address4",

                    },
                    new RegisteredUser
                    {
                        Id = 5,
                        FirstName = "User5",
                        LastName = "555",
                        UserName = "user5",
                        Password = "password5",
                        Role = RegisteredUserRole.RegisteredUser,
                        Email = "user5@gmai.com",
                        Phone = "(068)-425-64-21",
                        Address = "address5",

                    }
                );


            modelBuilder.Entity<WaterPoint>().HasData(
                    new WaterPoint
                    {
                        Id = 1, 
                        Title = "WaterPoint1",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        WaterPointType = WaterPointType.WaterDelivery,
                        PhoneNumber = "(068)-555-55-55",
                        Address = "WaterPoint_address1",
                        Rating = 3d,
                        IsVerified = true,
                        HasOrdering = true,
                        HasDelivery = true,
                        HasSearchPriority = false,
                        UserId = 2,
                        VerificationDocumentId = 1,
                    },
                    new WaterPoint
                    {
                        Id = 2,
                        Title = "WaterPoint2",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        WaterPointType = WaterPointType.PumpStation,
                        PhoneNumber = "(068)-555-66-77",
                        Address = "WaterPoint_address2",
                        Rating = 4d,
                        IsVerified = true,
                        HasOrdering = false,
                        HasDelivery = false,
                        HasSearchPriority = false,
                        UserId = 2,
                        VerificationDocumentId = 2,
                    },
                    new WaterPoint
                    {
                        Id = 3,
                        Title = "WaterPoint3",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        WaterPointType = WaterPointType.WaterDelivery,
                        PhoneNumber = "(068)-123-33-33",
                        Address = "WaterPoint_address3",
                        Rating = 3.5d,
                        IsVerified = true,
                        HasOrdering = true,
                        HasDelivery = true,
                        HasSearchPriority = false,
                        UserId = 2,
                        VerificationDocumentId = 1,
                    }
                );

            modelBuilder.Entity<Review>().HasData(
                    new Review
                    {
                        Id = 1,
                        WaterPointId = 1,
                        UserId = 1,
                        Rating = 3,
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    },
                    new Review
                    {
                        Id = 2,
                        WaterPointId = 2,
                        UserId = 1,
                        Rating = 5,
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    },
                    new Review
                    {
                        Id = 3,
                        WaterPointId = 2,
                        UserId = 2,
                        Rating = 3,
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    },
                    new Review
                    {
                        Id = 4,
                        WaterPointId = 3,
                        UserId = 1,
                        Rating = 4,
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    },
                    new Review
                    {
                        Id = 5,
                        WaterPointId = 3,
                        UserId = 2,
                        Rating = 3,
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    }
                );


        }
    }
}
