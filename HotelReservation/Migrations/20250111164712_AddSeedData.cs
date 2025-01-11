using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Amenities_AmenitiesId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Location_LocationId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_AmenitiesId",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "AmenitiesId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "PricePerNight",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HasBbq",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasCurencyExcenge",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasFitenssCenter",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasFrontDesck24",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasGameRoom",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasInternet",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasLounge",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasMiniBar",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasNetflix",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasNoSmokingRooms",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasPoolParkour",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasPrivateParking",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasRestaurant",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasRoomService",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasSPA",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasSaturdayNight",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasSmokingArea",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasSwimmingPool",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "HasVideoGames",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "PetsAllowed",
                table: "Amenities");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameColumn(
                name: "AmenitiesId",
                table: "Amenities",
                newName: "AmenityId");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Locations",
                newName: "State");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Hotels",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "LocationId");

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "HotelAmenities",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAmenities", x => new { x.HotelId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_HotelAmenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelAmenities_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "AmenityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Free high-speed wireless internet", "WiFi" },
                    { 2, "Outdoor swimming pool", "Pool" },
                    { 3, "Fully equipped fitness center", "Gym" },
                    { 4, "Full-service spa offering massages, facials, and relaxation therapies", "Spa" },
                    { 5, "On-site restaurant with a variety of cuisines", "Restaurant" },
                    { 6, "Business center with high-speed internet and meeting rooms", "Business Center" },
                    { 7, "Free shuttle service to and from the airport", "Airport Shuttle" },
                    { 8, "Complimentary parking for guests", "Parking" },
                    { 9, "Hotel allows pets with designated pet rooms", "Pet-Friendly" },
                    { 10, "Personalized concierge service for reservations, tours, and more", "Concierge Service" },
                    { 11, "24-hour room service with a variety of menu options", "Room Service" },
                    { 12, "Flexible meeting and event spaces for business or personal gatherings", "Event Space" },
                    { 13, "Stylish lounge area with a selection of drinks and snacks", "Lounge" },
                    { 14, "Yoga, pilates, and fitness classes available to guests", "Fitness Classes" },
                    { 15, "On-site bar serving cocktails, beer, and wine", "Bar" }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "GuestId", "CreatedAt", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2894), "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2897), "jane.smith@example.com", "Jane", "Smith", "987-654-3210" },
                    { 3, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2900), "michael.johnson@example.com", "Michael", "Johnson", "555-123-4567" },
                    { 4, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2902), "emily.davis@example.com", "Emily", "Davis", "555-234-5678" },
                    { 5, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2905), "david.martinez@example.com", "David", "Martinez", "555-345-6789" },
                    { 6, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2907), "olivia.lopez@example.com", "Olivia", "Lopez", "555-456-7890" },
                    { 7, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2910), "james.garcia@example.com", "James", "Garcia", "555-567-8901" },
                    { 8, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2912), "sophia.harris@example.com", "Sophia", "Harris", "555-678-9012" },
                    { 9, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2915), "william.brown@example.com", "William", "Brown", "555-789-0123" },
                    { 10, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2917), "charlotte.clark@example.com", "Charlotte", "Clark", "555-890-1234" },
                    { 11, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2920), "benjamin.wilson@example.com", "Benjamin", "Wilson", "555-901-2345" },
                    { 12, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2922), "isabella.young@example.com", "Isabella", "Young", "555-012-3456" },
                    { 13, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2925), "lucas.allen@example.com", "Lucas", "Allen", "555-123-6789" },
                    { 14, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2928), "amelia.sanchez@example.com", "Amelia", "Sanchez", "555-234-8901" },
                    { 15, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2931), "ethan.thomas@example.com", "Ethan", "Thomas", "555-345-9012" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "City", "Country", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "New York", "USA", "10001", "NY" },
                    { 2, "456 High Street", "San Francisco", "USA", "94101", "CA" },
                    { 3, "789 Ocean Avenue", "Miami", "USA", "33101", "FL" },
                    { 4, "101 Lakeview Drive", "Chicago", "USA", "60601", "IL" },
                    { 5, "202 Mountain Road", "Denver", "USA", "80202", "CO" },
                    { 6, "303 Sunset Boulevard", "Los Angeles", "USA", "90001", "CA" },
                    { 7, "404 Maple Street", "Toronto", "Canada", "M5H 2N2", "ON" },
                    { 8, "505 Rainforest Lane", "Seattle", "USA", "98101", "WA" },
                    { 9, "606 Desert Drive", "Phoenix", "USA", "85001", "AZ" },
                    { 10, "707 Skyline Avenue", "Atlanta", "USA", "30301", "GA" },
                    { 11, "808 Bay Street", "San Diego", "USA", "92101", "CA" },
                    { 12, "909 Hillcrest Road", "Austin", "USA", "73301", "TX" },
                    { 13, "123 Orchard Lane", "Vancouver", "Canada", "V6B 2K4", "BC" },
                    { 14, "456 Alpine Trail", "Salt Lake City", "USA", "84101", "UT" },
                    { 15, "789 Harbor Drive", "Boston", "USA", "02108", "MA" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "CreatedAt", "Description", "IsAvailable", "LocationId", "Name", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2628), "A luxury hotel with modern amenities.", true, 1, "Luxury Stay", 0, null },
                    { 2, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2684), "Affordable accommodation for travelers.", true, 2, "Budget Inn", 0, null },
                    { 3, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2686), "A luxury palace with royal rooms and services.", true, 3, "The Grand Palace", 0, null },
                    { 4, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2688), "A modern resort with breathtaking views of the mountains.", true, 4, "Skyline Resort", 0, null },
                    { 5, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2689), "A tranquil retreat in the desert with an all-inclusive experience.", true, 5, "Desert Oasis", 0, null },
                    { 6, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2691), "An oceanfront hotel offering water sports and excursions.", true, 6, "Blue Lagoon Hotel", 0, null },
                    { 7, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2693), "A cozy lodge nestled in the mountains with hiking trails.", true, 7, "Mountain View Lodge", 0, null },
                    { 8, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2695), "A stylish boutique hotel located in the heart of downtown.", true, 8, "Urban Escape", 0, null },
                    { 9, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2696), "A beachfront inn with stunning ocean views.", true, 9, "The Sea Breeze Inn", 0, null },
                    { 10, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2698), "A contemporary hotel with an outdoor pool and rooftop bar.", true, 10, "City Lights Hotel", 0, null },
                    { 11, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2700), "A 5-star resort with luxury amenities and fine dining.", true, 11, "Golden Sands Resort", 0, null },
                    { 12, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2701), "A serene hotel in the forest with eco-friendly practices.", true, 12, "Forest Retreat", 0, null },
                    { 13, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2750), "A lakeside hotel offering boat tours and fishing activities.", true, 13, "Lakeview Grand", 0, null },
                    { 14, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2752), "An exclusive hotel with luxurious rooms and a private spa.", true, 14, "Sapphire Palace", 0, null },
                    { 15, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2755), "A refined hotel with manicured gardens and elegant dining.", true, 15, "Royal Garden Hotel", 0, null }
                });

            migrationBuilder.InsertData(
                table: "HotelAmenities",
                columns: new[] { "AmenityId", "HotelId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 1, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 4 },
                    { 11, 4 },
                    { 12, 5 },
                    { 13, 5 },
                    { 14, 6 },
                    { 15, 6 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Capacity", "HotelId", "IsAvailable", "PricePerNight", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 1, 4, 1, true, 300.00m, "101", "Suite" },
                    { 2, 2, 1, true, 200.00m, "102", "Double" },
                    { 3, 1, 2, true, 100.00m, "201", "Single" },
                    { 4, 4, 1, true, 500.00m, "103", "Penthouse" },
                    { 5, 2, 1, true, 350.00m, "104", "Junior Suite" },
                    { 6, 2, 2, true, 150.00m, "202", "Double" },
                    { 7, 1, 2, true, 80.00m, "203", "Single" },
                    { 8, 4, 3, true, 400.00m, "301", "Suite" },
                    { 9, 2, 3, true, 220.00m, "302", "Double" },
                    { 10, 2, 4, true, 120.00m, "401", "Studio" },
                    { 11, 3, 4, true, 300.00m, "402", "Deluxe" },
                    { 12, 4, 5, true, 450.00m, "501", "King Suite" },
                    { 13, 5, 5, true, 250.00m, "502", "Family Room" },
                    { 14, 3, 6, true, 600.00m, "601", "Oceanfront Suite" },
                    { 15, 2, 6, true, 200.00m, "602", "Standard" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingStatus", "CheckInDate", "CheckOutDate", "GuestId", "RoomId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2960), "Confirmed", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1500.00m },
                    { 2, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2963), "Confirmed", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 500.00m },
                    { 3, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2969), "Confirmed", new DateTime(2025, 1, 13, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2964), new DateTime(2025, 1, 18, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2968), 3, 4, 1500.00m },
                    { 4, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2973), "Confirmed", new DateTime(2025, 1, 16, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2971), new DateTime(2025, 1, 21, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2972), 4, 5, 1750.00m },
                    { 5, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2977), "Confirmed", new DateTime(2025, 1, 14, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2975), new DateTime(2025, 1, 19, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2976), 5, 6, 1200.00m },
                    { 6, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2981), "Confirmed", new DateTime(2025, 1, 12, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2979), new DateTime(2025, 1, 17, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2980), 6, 7, 1100.00m },
                    { 7, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2985), "Confirmed", new DateTime(2025, 1, 18, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2982), new DateTime(2025, 1, 23, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2984), 7, 8, 1300.00m },
                    { 8, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2989), "Confirmed", new DateTime(2025, 1, 15, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2987), new DateTime(2025, 1, 20, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2988), 8, 9, 1400.00m },
                    { 9, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2993), "Confirmed", new DateTime(2025, 1, 13, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2991), new DateTime(2025, 1, 18, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2992), 9, 10, 1600.00m },
                    { 10, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2997), "Confirmed", new DateTime(2025, 1, 14, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2995), new DateTime(2025, 1, 19, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(2996), 10, 11, 1900.00m },
                    { 11, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3026), "Confirmed", new DateTime(2025, 1, 17, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3024), new DateTime(2025, 1, 22, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3025), 11, 12, 2100.00m },
                    { 12, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3030), "Confirmed", new DateTime(2025, 1, 12, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3028), new DateTime(2025, 1, 17, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3029), 12, 13, 1800.00m },
                    { 13, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3034), "Confirmed", new DateTime(2025, 1, 13, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3032), new DateTime(2025, 1, 18, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3033), 13, 14, 2200.00m },
                    { 14, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3038), "Confirmed", new DateTime(2025, 1, 14, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3036), new DateTime(2025, 1, 19, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3037), 14, 15, 2500.00m },
                    { 15, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3042), "Confirmed", new DateTime(2025, 1, 16, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3039), new DateTime(2025, 1, 21, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3041), 15, 4, 1600.00m }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "BookingId", "PaymentDate", "PaymentMethod", "PaymentStatus" },
                values: new object[,]
                {
                    { 1, 1500.00m, 1, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3067), "Credit Card", "Paid" },
                    { 2, 500.00m, 2, new DateTime(2025, 1, 11, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3070), "Cash", "Paid" },
                    { 3, 1500.00m, 3, new DateTime(2025, 1, 12, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3072), "Credit Card", "Completed" },
                    { 4, 1750.00m, 4, new DateTime(2025, 1, 13, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3075), "Debit Card", "Completed" },
                    { 5, 1200.00m, 5, new DateTime(2025, 1, 12, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3076), "PayPal", "Completed" },
                    { 6, 1100.00m, 6, new DateTime(2025, 1, 14, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3078), "Credit Card", "Completed" },
                    { 7, 1300.00m, 7, new DateTime(2025, 1, 12, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3080), "Credit Card", "Completed" },
                    { 8, 1400.00m, 8, new DateTime(2025, 1, 13, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3082), "Debit Card", "Completed" },
                    { 9, 1600.00m, 9, new DateTime(2025, 1, 12, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3084), "Credit Card", "Pending" },
                    { 10, 1900.00m, 10, new DateTime(2025, 1, 14, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3086), "PayPal", "Completed" },
                    { 11, 2100.00m, 11, new DateTime(2025, 1, 13, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3088), "Bank Transfer", "Completed" },
                    { 12, 1800.00m, 12, new DateTime(2025, 1, 12, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3090), "Debit Card", "Completed" },
                    { 13, 2200.00m, 13, new DateTime(2025, 1, 13, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3091), "Credit Card", "Completed" },
                    { 14, 2500.00m, 14, new DateTime(2025, 1, 12, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3093), "PayPal", "Completed" },
                    { 15, 1600.00m, 15, new DateTime(2025, 1, 14, 17, 47, 12, 410, DateTimeKind.Local).AddTicks(3095), "Bank Transfer", "Pending" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAmenities_AmenityId",
                table: "HotelAmenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "HotelAmenities");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "AmenityId",
                table: "Amenities",
                newName: "AmenitiesId");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Location",
                newName: "ZipCode");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmenitiesId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PricePerNight",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasBbq",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasCurencyExcenge",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFitenssCenter",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFrontDesck24",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasGameRoom",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasInternet",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasLounge",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMiniBar",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasNetflix",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasNoSmokingRooms",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPoolParkour",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPrivateParking",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRestaurant",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRoomService",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSPA",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSaturdayNight",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSmokingArea",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSwimmingPool",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasVideoGames",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PetsAllowed",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "LocationId");

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_AmenitiesId",
                table: "Hotels",
                column: "AmenitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Amenities_AmenitiesId",
                table: "Hotels",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "AmenitiesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Location_LocationId",
                table: "Hotels",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
