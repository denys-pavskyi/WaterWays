using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisteredUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderText = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsToBeDelivered = table.Column<bool>(type: "bit", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_RegisteredUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificationDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterPointId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerificationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationDocuments_RegisteredUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WaterPointType = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    HasOrdering = table.Column<bool>(type: "bit", nullable: false),
                    HasOwnDelivery = table.Column<bool>(type: "bit", nullable: false),
                    HasSearchPriority = table.Column<bool>(type: "bit", nullable: false),
                    photoUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VerificationDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterPoints_RegisteredUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaterPoints_VerificationDocuments_VerificationDocumentId",
                        column: x => x.VerificationDocumentId,
                        principalTable: "VerificationDocuments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    WaterPointId = table.Column<int>(type: "int", nullable: false),
                    photoUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityAvailable = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_WaterPoints_WaterPointId",
                        column: x => x.WaterPointId,
                        principalTable: "WaterPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterPointId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UploadedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_RegisteredUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_WaterPoints_WaterPointId",
                        column: x => x.WaterPointId,
                        principalTable: "WaterPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_RegisteredUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Password", "Phone", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "address1", "user1@gmai.com", "User1", "111", "password1", "(068)-111-11-11", 0, "user1" },
                    { 2, "address2", "user2@gmai.com", "Representative2", "222", "password2", "(068)-222-22-22", 1, "user2" },
                    { 3, "address3", "user3@gmai.com", "Representative3", "333", "password3", "(068)-333-33-33", 1, "user3" },
                    { 4, "address4", "user4@gmai.com", "Admin4", "444", "password4", "(068)-444-44-44", 2, "user4" },
                    { 5, "address5", "user5@gmai.com", "User5", "555", "password5", "(068)-425-64-21", 0, "user5" },
                    { 6, "address6", "user6@gmai.com", "Representative6", "last_name6", "password6", "(068)-635-56-33", 1, "user6" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "ContactPhone", "IsToBeDelivered", "OrderDate", "OrderStatus", "OrderText", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, "address1", "(068)-111-11-11", true, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat", 70m, 1 },
                    { 2, "address1", "(068)-111-11-11", true, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat", 50m, 1 }
                });

            migrationBuilder.InsertData(
                table: "VerificationDocuments",
                columns: new[] { "Id", "DocumentLink", "UploadDate", "UserId", "VerificationStatus", "WaterPointId" },
                values: new object[,]
                {
                    { 1, "doc_link1", new DateTime(2020, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 1 },
                    { 2, "doc_link2", new DateTime(2018, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, 2 },
                    { 3, "doc_link3", new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, 3 },
                    { 4, "doc_link4", new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 4 },
                    { 5, "doc_link5", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 5 },
                    { 6, "doc_link6", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 6 },
                    { 7, "doc_link7", new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 7 }
                });

            migrationBuilder.InsertData(
                table: "WaterPoints",
                columns: new[] { "Id", "Address", "Description", "HasOrdering", "HasOwnDelivery", "HasSearchPriority", "IsVerified", "PhoneNumber", "Rating", "Title", "UserId", "VerificationDocumentId", "WaterPointType", "photoUrl" },
                values: new object[,]
                {
                    { 1, "10, Kreshchatyk St, Kyiv", "private water point offers high-quality purified drinking water for purchase", true, true, false, true, "(068)-555-55-55", 3.0, "Aqua Pure", 2, 1, 1, "water_delivery1.png" },
                    { 2, "2, Hrushevskoho St, Kyiv", "pump station offers a free water dispenser for the public to use. It is a community-funded initiative to provide clean and safe drinking water for all", false, false, false, true, "(068)-555-66-77", 4.0, "Pump station №452", 3, 2, 0, "pump_station1.jpg" },
                    { 3, "5, Volodymyrska St, Kyiv", "private water point sells natural spring water sourced from a nearby mountain", true, true, false, true, "(068)-123-33-33", 3.5, "Blue Spring", 3, 3, 1, "water_delivery2.jpg" },
                    { 4, "20, Shevchenka Blvd, Kyiv", "pump station provides free drinking water to the public. The water is regularly tested and meets all safety standards.", false, true, false, true, "(068)-123-58-77", 0.0, "Pump station #286", 2, 4, 0, "pump_station2.jpg" },
                    { 5, "30, Velyka Vasylkivska St, Kyiv", "supermarket specializes in selling various types of water, from purified drinking water to mineral water, flavored water, and even water in glass bottles.", true, true, false, true, "(068)-776-58-77", 0.0, "Aqua Market", 2, 5, 2, "water_shop1.jpg" },
                    { 6, "20, Tarasa Shevchenka Blvd, Kyiv", "private water point sells alkaline water that is believed to have health benefits", true, true, false, false, "(068)-776-58-77", 0.0, "Aqua Vita", 6, 6, 1, "water_delivery3.jpg" },
                    { 7, "25, Khreschatyk St, Kyiv", "private water point sells deep ocean water, harvested from the depths of the Black Sea, that is known for its high mineral content and unique taste", true, true, false, false, "(068)-776-58-77", 0.0, "Deep Blue", 6, 7, 1, "water_delivery4.PNG" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "QuantityAvailable", "Title", "Type", "WaterPointId", "photoUrl" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", 5.5m, 100m, "Bottled water", 0, 1, "still_water1.png" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", 6.5m, 150m, "Bottled sparkling water", 1, 1, "sparkling1.PNG" },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", 15m, 100m, "Water filters", 3, 1, "water-filters1.jpg" },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", 5m, 200m, "Still drinkable water", 0, 3, "still_water2l.jpg" },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", 2m, 200m, "Industrial water water", 2, 3, "industrial_water1.jpg" },
                    { 6, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", 100m, 20m, "Water cooler", 3, 1, "water_cooler1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Rating", "ReviewText", "UploadedOn", "UserId", "WaterPointId" },
                values: new object[,]
                {
                    { 1, 3, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 5, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 3, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 4, 4, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 5, 3, "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod temDuisfugiat nulla pariaecat cupidata deserunt mollit anim id est laborum", new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 1, 1, 5, 20m, 40m, 2m });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 2, 1, 6, 3m, 300m, 100m });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 3, 2, 4, 10m, 50m, 5m });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WaterPointId",
                table: "Products",
                column: "WaterPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_WaterPointId",
                table: "Reviews",
                column: "WaterPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationDocuments_UserId",
                table: "VerificationDocuments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterPoints_UserId",
                table: "WaterPoints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterPoints_VerificationDocumentId",
                table: "WaterPoints",
                column: "VerificationDocumentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WaterPoints");

            migrationBuilder.DropTable(
                name: "VerificationDocuments");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");
        }
    }
}
