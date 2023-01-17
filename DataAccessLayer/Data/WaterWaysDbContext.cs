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
                .HasOne(x => x.WaterPoint).WithOne(x => x.VerificationDocument).HasForeignKey<VerificationDocument>(x => x.WaterPointId).OnDelete(DeleteBehavior.NoAction);
           

            modelBuilder.Entity<WaterPoint>()
                .HasOne(x => x.VerificationDocument).WithOne(x => x.WaterPoint).HasForeignKey<WaterPoint>(x => x.VerificationDocumentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<WaterPoint>()
                .HasMany(x => x.Reviews).WithOne(x => x.WaterPoint).HasForeignKey(x => x.WaterPointId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WaterPoint>()
                .HasMany(x => x.Products).WithOne(x => x.WaterPoint).HasForeignKey(x => x.WaterPointId).OnDelete(DeleteBehavior.Cascade);




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
                        HasOwnDelivery = true,
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
                        HasOwnDelivery = false,
                        HasSearchPriority = false,
                        UserId = 3,
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
                        HasOwnDelivery = true,
                        HasSearchPriority = false,
                        UserId = 3,
                        VerificationDocumentId = 3,
                    },
                    new WaterPoint
                    {
                        Id = 4,
                        Title = "WaterPoint4",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        WaterPointType = WaterPointType.PumpStation,
                        PhoneNumber = "(068)-123-58-77",
                        Address = "WaterPoint_address4",
                        Rating = 4d,
                        IsVerified = true,
                        HasOrdering = true,
                        HasOwnDelivery = true,
                        HasSearchPriority = false,
                        UserId = 2,
                        VerificationDocumentId = 4,
                    },
                    new WaterPoint
                    {
                        Id = 5,
                        Title = "WaterPoint5",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        WaterPointType = WaterPointType.Shop,
                        PhoneNumber = "(068)-776-58-77",
                        Address = "WaterPoint_address5",
                        Rating = 5d,
                        IsVerified = true,
                        HasOrdering = true,
                        HasOwnDelivery = true,
                        HasSearchPriority = false,
                        UserId = 2,
                        VerificationDocumentId = 5,
                    }
                );

            modelBuilder.Entity<Review>().HasData(
                    new Review
                    {
                        Id = 1,
                        WaterPointId = 1,
                        UserId = 1,
                        Rating = 3,
                        UploadedOn = new DateTime(2023,1,10),
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    },
                    new Review
                    {
                        Id = 2,
                        WaterPointId = 2,
                        UserId = 1,
                        Rating = 5,
                        UploadedOn = new DateTime(2023, 1, 11),
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    },
                    new Review
                    {
                        Id = 3,
                        WaterPointId = 2,
                        UserId = 2,
                        Rating = 3,
                        UploadedOn = new DateTime(2023, 1, 12),
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    },
                    new Review
                    {
                        Id = 4,
                        WaterPointId = 3,
                        UserId = 1,
                        Rating = 4,
                        UploadedOn = new DateTime(2023, 1, 13),
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    },
                    new Review
                    {
                        Id = 5,
                        WaterPointId = 3,
                        UserId = 2,
                        Rating = 3,
                        UploadedOn = new DateTime(2023, 1, 14),
                        ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum"
                    }
                );

            modelBuilder.Entity<VerificationDocument>().HasData(
                    new VerificationDocument
                    {
                        Id = 1,
                        WaterPointId = 1,
                        UserId = 2,
                        DocumentLink = "doc_link1",
                        UploadDate = new DateTime(2020, 6, 16),
                        VerificationStatus = VerificationStatus.Approved
                    },
                    new VerificationDocument
                    {
                        Id = 2,
                        WaterPointId = 2,
                        UserId = 3,
                        DocumentLink = "doc_link2",
                        UploadDate = new DateTime(2018,2,3),
                        VerificationStatus = VerificationStatus.Approved
                    },
                    new VerificationDocument
                    {
                        Id = 3,
                        WaterPointId = 3,
                        UserId = 3,
                        DocumentLink = "doc_link3",
                        UploadDate = new DateTime(2019, 10, 23),
                        VerificationStatus = VerificationStatus.Approved
                    },
                    new VerificationDocument
                    {
                        Id = 4,
                        WaterPointId = 4,
                        UserId = 2,
                        DocumentLink = "doc_link4",
                        UploadDate = new DateTime(2023, 1, 2),
                        VerificationStatus = VerificationStatus.Approved
                    },
                    new VerificationDocument
                    {
                        Id = 5,
                        WaterPointId = 5,
                        UserId = 2,
                        DocumentLink = "doc_link5",
                        UploadDate = new DateTime(2023, 1, 1),
                        VerificationStatus = VerificationStatus.Approved
                    }

                );


            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "Bottled water",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        Type = ProductType.StillWater,
                        Price = 5.5m,
                        QuantityAvailable = 100,
                        WaterPointId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "Bottled sparkling water",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        Type = ProductType.SparklingWater,
                        Price = 6.5m,
                        QuantityAvailable = 150,
                        WaterPointId = 1
                    },
                    new Product
                    {
                        Id = 3,
                        Title = "Water filters",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        Type = ProductType.Other,
                        Price = 15m,
                        QuantityAvailable = 100,
                        WaterPointId = 1
                    },
                    new Product
                    {
                        Id = 4,
                        Title = "Still drinkable water",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        Type = ProductType.StillWater,
                        Price = 5m,
                        QuantityAvailable = 200,
                        WaterPointId = 3
                    },
                    new Product
                    {
                        Id = 5,
                        Title = "Industrial water water",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        Type = ProductType.IndustrialWater,
                        Price = 2m,
                        QuantityAvailable = 200,
                        WaterPointId = 3
                    },
                    new Product
                    {
                        Id = 6,
                        Title = "Plastic bottle 5 liter",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                        Type = ProductType.Other,
                        Price = 10m,
                        QuantityAvailable = 100,
                        WaterPointId = 1
                    }

                );

            modelBuilder.Entity<Order>().HasData(
                    new Order
                    {
                        Id = 1,
                        OrderText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat",
                        UserId = 1,
                        ContactPhone = "(068)-111-11-11",
                        OrderDate = new DateTime(2022, 01, 12),
                        Address = "address1",
                        TotalPrice = 70m,
                        IsToBeDelivered = true,
                        OrderStatus = OrderStatus.Done
                    },
                    new Order
                    {
                        Id = 2,
                        OrderText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat",
                        UserId = 1,
                        ContactPhone = "(068)-111-11-11",
                        OrderDate = new DateTime(2022, 01, 13),
                        Address = "address1",
                        TotalPrice = 50m,
                        IsToBeDelivered = true,
                        OrderStatus = OrderStatus.OnDelivery
                    }

                );

            modelBuilder.Entity<OrderDetail>().HasData(
                    new OrderDetail
                    {
                        Id = 1,
                        OrderId = 1,
                        ProductId = 5,
                        Quantity = 20,
                        UnitPrice = 2m,
                        TotalPrice = 40m
                    },
                    new OrderDetail
                    {
                        Id = 2,
                        OrderId = 1,
                        ProductId = 6,
                        Quantity = 3,
                        UnitPrice = 10m,
                        TotalPrice = 30m
                    },
                    new OrderDetail
                    {
                        Id = 3,
                        OrderId = 2,
                        ProductId = 4,
                        Quantity = 10,
                        UnitPrice = 5m,
                        TotalPrice = 50m
                    }

                );

        }
    }
}
