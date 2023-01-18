﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(WaterWaysDbContext))]
    partial class WaterWaysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccessLayer.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsToBeDelivered")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("OrderText")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "address1",
                            ContactPhone = "(068)-111-11-11",
                            IsToBeDelivered = true,
                            OrderDate = new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 0,
                            OrderText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat",
                            TotalPrice = 70m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "address1",
                            ContactPhone = "(068)-111-11-11",
                            IsToBeDelivered = true,
                            OrderDate = new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderStatus = 3,
                            OrderText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat",
                            TotalPrice = 50m,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 5,
                            Quantity = 20m,
                            TotalPrice = 40m,
                            UnitPrice = 2m
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            ProductId = 6,
                            Quantity = 3m,
                            TotalPrice = 300m,
                            UnitPrice = 100m
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            ProductId = 4,
                            Quantity = 10m,
                            TotalPrice = 50m,
                            UnitPrice = 5m
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuantityAvailable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("WaterPointId")
                        .HasColumnType("int");

                    b.Property<string>("photoUrl")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("WaterPointId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            Price = 5.5m,
                            QuantityAvailable = 100m,
                            Title = "Bottled water",
                            Type = 0,
                            WaterPointId = 1,
                            photoUrl = "still_water1.png"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            Price = 6.5m,
                            QuantityAvailable = 150m,
                            Title = "Bottled sparkling water",
                            Type = 1,
                            WaterPointId = 1,
                            photoUrl = "sparkling1.PNG"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            Price = 15m,
                            QuantityAvailable = 100m,
                            Title = "Water filters",
                            Type = 3,
                            WaterPointId = 1,
                            photoUrl = "water-filters1.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            Price = 5m,
                            QuantityAvailable = 200m,
                            Title = "Still drinkable water",
                            Type = 0,
                            WaterPointId = 3,
                            photoUrl = "still_water2l.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            Price = 2m,
                            QuantityAvailable = 200m,
                            Title = "Industrial water water",
                            Type = 2,
                            WaterPointId = 3,
                            photoUrl = "industrial_water1.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            Price = 100m,
                            QuantityAvailable = 20m,
                            Title = "Water cooler",
                            Type = 3,
                            WaterPointId = 1,
                            photoUrl = "water_cooler1.jpg"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.RegisteredUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("RegisteredUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "address1",
                            Email = "user1@gmai.com",
                            FirstName = "User1",
                            LastName = "111",
                            Password = "password1",
                            Phone = "(068)-111-11-11",
                            Role = 0,
                            UserName = "user1"
                        },
                        new
                        {
                            Id = 2,
                            Address = "address2",
                            Email = "user2@gmai.com",
                            FirstName = "Representative2",
                            LastName = "222",
                            Password = "password2",
                            Phone = "(068)-222-22-22",
                            Role = 1,
                            UserName = "user2"
                        },
                        new
                        {
                            Id = 3,
                            Address = "address3",
                            Email = "user3@gmai.com",
                            FirstName = "Representative3",
                            LastName = "333",
                            Password = "password3",
                            Phone = "(068)-333-33-33",
                            Role = 1,
                            UserName = "user3"
                        },
                        new
                        {
                            Id = 4,
                            Address = "address4",
                            Email = "user4@gmai.com",
                            FirstName = "Admin4",
                            LastName = "444",
                            Password = "password4",
                            Phone = "(068)-444-44-44",
                            Role = 2,
                            UserName = "user4"
                        },
                        new
                        {
                            Id = 5,
                            Address = "address5",
                            Email = "user5@gmai.com",
                            FirstName = "User5",
                            LastName = "555",
                            Password = "password5",
                            Phone = "(068)-425-64-21",
                            Role = 0,
                            UserName = "user5"
                        },
                        new
                        {
                            Id = 6,
                            Address = "address6",
                            Email = "user6@gmai.com",
                            FirstName = "Representative6",
                            LastName = "last_name6",
                            Password = "password6",
                            Phone = "(068)-635-56-33",
                            Role = 1,
                            UserName = "user6"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("UploadedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WaterPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WaterPointId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Rating = 3,
                            ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            UploadedOn = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            WaterPointId = 1
                        },
                        new
                        {
                            Id = 2,
                            Rating = 5,
                            ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            UploadedOn = new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            WaterPointId = 2
                        },
                        new
                        {
                            Id = 3,
                            Rating = 3,
                            ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            UploadedOn = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2,
                            WaterPointId = 2
                        },
                        new
                        {
                            Id = 4,
                            Rating = 4,
                            ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            UploadedOn = new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            WaterPointId = 3
                        },
                        new
                        {
                            Id = 5,
                            Rating = 3,
                            ReviewText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum",
                            UploadedOn = new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2,
                            WaterPointId = 3
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.VerificationDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DocumentLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VerificationStatus")
                        .HasColumnType("int");

                    b.Property<int>("WaterPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("VerificationDocuments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DocumentLink = "doc_link1",
                            UploadDate = new DateTime(2020, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2,
                            VerificationStatus = 0,
                            WaterPointId = 1
                        },
                        new
                        {
                            Id = 2,
                            DocumentLink = "doc_link2",
                            UploadDate = new DateTime(2018, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3,
                            VerificationStatus = 0,
                            WaterPointId = 2
                        },
                        new
                        {
                            Id = 3,
                            DocumentLink = "doc_link3",
                            UploadDate = new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 3,
                            VerificationStatus = 0,
                            WaterPointId = 3
                        },
                        new
                        {
                            Id = 4,
                            DocumentLink = "doc_link4",
                            UploadDate = new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2,
                            VerificationStatus = 0,
                            WaterPointId = 4
                        },
                        new
                        {
                            Id = 5,
                            DocumentLink = "doc_link5",
                            UploadDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2,
                            VerificationStatus = 0,
                            WaterPointId = 5
                        },
                        new
                        {
                            Id = 6,
                            DocumentLink = "doc_link6",
                            UploadDate = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 6,
                            VerificationStatus = 2,
                            WaterPointId = 6
                        },
                        new
                        {
                            Id = 7,
                            DocumentLink = "doc_link7",
                            UploadDate = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 6,
                            VerificationStatus = 2,
                            WaterPointId = 7
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.WaterPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("HasOrdering")
                        .HasColumnType("bit");

                    b.Property<bool>("HasOwnDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("HasSearchPriority")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VerificationDocumentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("WaterPointType")
                        .HasColumnType("int");

                    b.Property<string>("photoUrl")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VerificationDocumentId")
                        .IsUnique();

                    b.ToTable("WaterPoints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "10, Kreshchatyk St, Kyiv",
                            Description = "private water point offers high-quality purified drinking water for purchase",
                            HasOrdering = true,
                            HasOwnDelivery = true,
                            HasSearchPriority = false,
                            IsVerified = true,
                            PhoneNumber = "(068)-555-55-55",
                            Rating = 3.0,
                            Title = "Aqua Pure",
                            UserId = 2,
                            VerificationDocumentId = 1,
                            WaterPointType = 1,
                            photoUrl = "water_delivery1.png"
                        },
                        new
                        {
                            Id = 2,
                            Address = "2, Hrushevskoho St, Kyiv",
                            Description = "pump station offers a free water dispenser for the public to use. It is a community-funded initiative to provide clean and safe drinking water for all",
                            HasOrdering = false,
                            HasOwnDelivery = false,
                            HasSearchPriority = false,
                            IsVerified = true,
                            PhoneNumber = "(068)-555-66-77",
                            Rating = 4.0,
                            Title = "Pump station №452",
                            UserId = 3,
                            VerificationDocumentId = 2,
                            WaterPointType = 0,
                            photoUrl = "pump_station2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Address = "5, Volodymyrska St, Kyiv",
                            Description = "private water point sells natural spring water sourced from a nearby mountain",
                            HasOrdering = true,
                            HasOwnDelivery = true,
                            HasSearchPriority = false,
                            IsVerified = true,
                            PhoneNumber = "(068)-123-33-33",
                            Rating = 3.5,
                            Title = "Blue Spring",
                            UserId = 3,
                            VerificationDocumentId = 3,
                            WaterPointType = 1,
                            photoUrl = "water_delivery2.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Address = "20, Shevchenka Blvd, Kyiv",
                            Description = "pump station provides free drinking water to the public. The water is regularly tested and meets all safety standards.",
                            HasOrdering = true,
                            HasOwnDelivery = true,
                            HasSearchPriority = false,
                            IsVerified = true,
                            PhoneNumber = "(068)-123-58-77",
                            Rating = 0.0,
                            Title = "Pump station #286",
                            UserId = 2,
                            VerificationDocumentId = 4,
                            WaterPointType = 0,
                            photoUrl = "pump_station2.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Address = "30, Velyka Vasylkivska St, Kyiv",
                            Description = "supermarket specializes in selling various types of water, from purified drinking water to mineral water, flavored water, and even water in glass bottles.",
                            HasOrdering = true,
                            HasOwnDelivery = true,
                            HasSearchPriority = false,
                            IsVerified = true,
                            PhoneNumber = "(068)-776-58-77",
                            Rating = 0.0,
                            Title = "Aqua Market",
                            UserId = 2,
                            VerificationDocumentId = 5,
                            WaterPointType = 2,
                            photoUrl = "water_shop1.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Address = "20, Tarasa Shevchenka Blvd, Kyiv",
                            Description = "private water point sells alkaline water that is believed to have health benefits",
                            HasOrdering = true,
                            HasOwnDelivery = true,
                            HasSearchPriority = false,
                            IsVerified = false,
                            PhoneNumber = "(068)-776-58-77",
                            Rating = 0.0,
                            Title = "Aqua Vita",
                            UserId = 6,
                            VerificationDocumentId = 6,
                            WaterPointType = 1,
                            photoUrl = "water_delivery3.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Address = "25, Khreschatyk St, Kyiv",
                            Description = "private water point sells deep ocean water, harvested from the depths of the Black Sea, that is known for its high mineral content and unique taste",
                            HasOrdering = true,
                            HasOwnDelivery = true,
                            HasSearchPriority = false,
                            IsVerified = false,
                            PhoneNumber = "(068)-776-58-77",
                            Rating = 0.0,
                            Title = "Deep Blue",
                            UserId = 6,
                            VerificationDocumentId = 7,
                            WaterPointType = 1,
                            photoUrl = "water_delivery4.PNG"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Order", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.RegisteredUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.OrderDetail", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Product", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.WaterPoint", "WaterPoint")
                        .WithMany("Products")
                        .HasForeignKey("WaterPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WaterPoint");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Review", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.RegisteredUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.WaterPoint", "WaterPoint")
                        .WithMany("Reviews")
                        .HasForeignKey("WaterPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WaterPoint");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ShoppingCart", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.RegisteredUser", "User")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.VerificationDocument", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.RegisteredUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.WaterPoint", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.RegisteredUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.VerificationDocument", "VerificationDocument")
                        .WithOne("WaterPoint")
                        .HasForeignKey("DataAccessLayer.Entities.WaterPoint", "VerificationDocumentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("VerificationDocument");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.RegisteredUser", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");

                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.VerificationDocument", b =>
                {
                    b.Navigation("WaterPoint")
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Entities.WaterPoint", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
