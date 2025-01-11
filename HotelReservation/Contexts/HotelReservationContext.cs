using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Contexts
{
    public class HotelReservationContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public HotelReservationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelAmenity> HotelAmenities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelAmenity>()
                .HasKey(ha => new { ha.HotelId, ha.AmenityId });

            modelBuilder.Entity<HotelAmenity>()
                .HasOne(ha => ha.Hotel)
                .WithMany(ha => ha.HotelAmenities)
                .HasForeignKey(ha => ha.HotelId);

            modelBuilder.Entity<HotelAmenity>()
                .HasOne(ha => ha.Amenity)
                .WithMany(ha => ha.HotelAmenities)
                .HasForeignKey(ha => ha.AmenityId);

            // Seed Locations
            modelBuilder.Entity<Location>().HasData(
                new Location { LocationId = 1, Address = "123 Main Street", City = "New York", State = "NY", Country = "USA", PostalCode = "10001" },
                new Location { LocationId = 2, Address = "456 High Street", City = "San Francisco", State = "CA", Country = "USA", PostalCode = "94101" },
                new Location { LocationId = 3, Address = "789 Ocean Avenue", City = "Miami", State = "FL", Country = "USA", PostalCode = "33101" },
                new Location { LocationId = 4, Address = "101 Lakeview Drive", City = "Chicago", State = "IL", Country = "USA", PostalCode = "60601" },
                new Location { LocationId = 5, Address = "202 Mountain Road", City = "Denver", State = "CO", Country = "USA", PostalCode = "80202" },
                new Location { LocationId = 6, Address = "303 Sunset Boulevard", City = "Los Angeles", State = "CA", Country = "USA", PostalCode = "90001" },
                new Location { LocationId = 7, Address = "404 Maple Street", City = "Toronto", State = "ON", Country = "Canada", PostalCode = "M5H 2N2" },
                new Location { LocationId = 8, Address = "505 Rainforest Lane", City = "Seattle", State = "WA", Country = "USA", PostalCode = "98101" },
                new Location { LocationId = 9, Address = "606 Desert Drive", City = "Phoenix", State = "AZ", Country = "USA", PostalCode = "85001" },
                new Location { LocationId = 10, Address = "707 Skyline Avenue", City = "Atlanta", State = "GA", Country = "USA", PostalCode = "30301" },
                new Location { LocationId = 11, Address = "808 Bay Street", City = "San Diego", State = "CA", Country = "USA", PostalCode = "92101" },
                new Location { LocationId = 12, Address = "909 Hillcrest Road", City = "Austin", State = "TX", Country = "USA", PostalCode = "73301" },
                new Location { LocationId = 13, Address = "123 Orchard Lane", City = "Vancouver", State = "BC", Country = "Canada", PostalCode = "V6B 2K4" },
                new Location { LocationId = 14, Address = "456 Alpine Trail", City = "Salt Lake City", State = "UT", Country = "USA", PostalCode = "84101" },
                new Location { LocationId = 15, Address = "789 Harbor Drive", City = "Boston", State = "MA", Country = "USA", PostalCode = "02108" }
            );

            // Seed Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { HotelId = 1, Name = "Luxury Stay", Description = "A luxury hotel with modern amenities.", LocationId = 1, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 2, Name = "Budget Inn", Description = "Affordable accommodation for travelers.", LocationId = 2, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 3, Name = "The Grand Palace", Description = "A luxury palace with royal rooms and services.", LocationId = 3, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 4, Name = "Skyline Resort", Description = "A modern resort with breathtaking views of the mountains.", LocationId = 4, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 5, Name = "Desert Oasis", Description = "A tranquil retreat in the desert with an all-inclusive experience.", LocationId = 5, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 6, Name = "Blue Lagoon Hotel", Description = "An oceanfront hotel offering water sports and excursions.", LocationId = 6, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 7, Name = "Mountain View Lodge", Description = "A cozy lodge nestled in the mountains with hiking trails.", LocationId = 7, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 8, Name = "Urban Escape", Description = "A stylish boutique hotel located in the heart of downtown.", LocationId = 8, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 9, Name = "The Sea Breeze Inn", Description = "A beachfront inn with stunning ocean views.", LocationId = 9, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 10, Name = "City Lights Hotel", Description = "A contemporary hotel with an outdoor pool and rooftop bar.", LocationId = 10, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 11, Name = "Golden Sands Resort", Description = "A 5-star resort with luxury amenities and fine dining.", LocationId = 11, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 12, Name = "Forest Retreat", Description = "A serene hotel in the forest with eco-friendly practices.", LocationId = 12, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 13, Name = "Lakeview Grand", Description = "A lakeside hotel offering boat tours and fishing activities.", LocationId = 13, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 14, Name = "Sapphire Palace", Description = "An exclusive hotel with luxurious rooms and a private spa.", LocationId = 14, CreatedAt = DateTime.Now, IsAvailable = true },
                new Hotel { HotelId = 15, Name = "Royal Garden Hotel", Description = "A refined hotel with manicured gardens and elegant dining.", LocationId = 15, CreatedAt = DateTime.Now, IsAvailable = true }
            );

            // Seed Amenities
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { AmenityId = 1, Name = "WiFi", Description = "Free high-speed wireless internet" },
                new Amenity { AmenityId = 2, Name = "Pool", Description = "Outdoor swimming pool" },
                new Amenity { AmenityId = 3, Name = "Gym", Description = "Fully equipped fitness center" },
                new Amenity { AmenityId = 4, Name = "Spa", Description = "Full-service spa offering massages, facials, and relaxation therapies" },
    new Amenity { AmenityId = 5, Name = "Restaurant", Description = "On-site restaurant with a variety of cuisines" },
    new Amenity { AmenityId = 6, Name = "Business Center", Description = "Business center with high-speed internet and meeting rooms" },
    new Amenity { AmenityId = 7, Name = "Airport Shuttle", Description = "Free shuttle service to and from the airport" },
    new Amenity { AmenityId = 8, Name = "Parking", Description = "Complimentary parking for guests" },
    new Amenity { AmenityId = 9, Name = "Pet-Friendly", Description = "Hotel allows pets with designated pet rooms" },
    new Amenity { AmenityId = 10, Name = "Concierge Service", Description = "Personalized concierge service for reservations, tours, and more" },
    new Amenity { AmenityId = 11, Name = "Room Service", Description = "24-hour room service with a variety of menu options" },
    new Amenity { AmenityId = 12, Name = "Event Space", Description = "Flexible meeting and event spaces for business or personal gatherings" },
    new Amenity { AmenityId = 13, Name = "Lounge", Description = "Stylish lounge area with a selection of drinks and snacks" },
    new Amenity { AmenityId = 14, Name = "Fitness Classes", Description = "Yoga, pilates, and fitness classes available to guests" },
    new Amenity { AmenityId = 15, Name = "Bar", Description = "On-site bar serving cocktails, beer, and wine" }

            );

            // Seed HotelAmenities
            modelBuilder.Entity<HotelAmenity>().HasData(
                new HotelAmenity { HotelId = 1, AmenityId = 1 },
                new HotelAmenity { HotelId = 1, AmenityId = 2 },
                new HotelAmenity { HotelId = 2, AmenityId = 1 },
                new HotelAmenity { HotelId = 1, AmenityId = 4 },
    new HotelAmenity { HotelId = 1, AmenityId = 5 },
    new HotelAmenity { HotelId = 2, AmenityId = 6 },
    new HotelAmenity { HotelId = 2, AmenityId = 7 },
    new HotelAmenity { HotelId = 3, AmenityId = 8 },
    new HotelAmenity { HotelId = 3, AmenityId = 9 },
    new HotelAmenity { HotelId = 4, AmenityId = 10 },
    new HotelAmenity { HotelId = 4, AmenityId = 11 },
    new HotelAmenity { HotelId = 5, AmenityId = 12 },
    new HotelAmenity { HotelId = 5, AmenityId = 13 },
    new HotelAmenity { HotelId = 6, AmenityId = 14 },
    new HotelAmenity { HotelId = 6, AmenityId = 15 }
            );

            // Seed Rooms
            modelBuilder.Entity<Room>().HasData(
                new Room { RoomId = 1, HotelId = 1, RoomNumber = "101", RoomType = "Suite", PricePerNight = 300.00m, IsAvailable = true, Capacity = 4 },
                new Room { RoomId = 2, HotelId = 1, RoomNumber = "102", RoomType = "Double", PricePerNight = 200.00m, IsAvailable = true, Capacity = 2 },
                new Room { RoomId = 3, HotelId = 2, RoomNumber = "201", RoomType = "Single", PricePerNight = 100.00m, IsAvailable = true, Capacity = 1 },
                new Room { RoomId = 4, HotelId = 1, RoomNumber = "103", RoomType = "Penthouse", PricePerNight = 500.00m, IsAvailable = true, Capacity = 4 },
    new Room { RoomId = 5, HotelId = 1, RoomNumber = "104", RoomType = "Junior Suite", PricePerNight = 350.00m, IsAvailable = true, Capacity = 2 },
    new Room { RoomId = 6, HotelId = 2, RoomNumber = "202", RoomType = "Double", PricePerNight = 150.00m, IsAvailable = true, Capacity = 2 },
    new Room { RoomId = 7, HotelId = 2, RoomNumber = "203", RoomType = "Single", PricePerNight = 80.00m, IsAvailable = true, Capacity = 1 },
    new Room { RoomId = 8, HotelId = 3, RoomNumber = "301", RoomType = "Suite", PricePerNight = 400.00m, IsAvailable = true, Capacity = 4 },
    new Room { RoomId = 9, HotelId = 3, RoomNumber = "302", RoomType = "Double", PricePerNight = 220.00m, IsAvailable = true, Capacity = 2 },
    new Room { RoomId = 10, HotelId = 4, RoomNumber = "401", RoomType = "Studio", PricePerNight = 120.00m, IsAvailable = true, Capacity = 2 },
    new Room { RoomId = 11, HotelId = 4, RoomNumber = "402", RoomType = "Deluxe", PricePerNight = 300.00m, IsAvailable = true, Capacity = 3 },
    new Room { RoomId = 12, HotelId = 5, RoomNumber = "501", RoomType = "King Suite", PricePerNight = 450.00m, IsAvailable = true, Capacity = 4 },
    new Room { RoomId = 13, HotelId = 5, RoomNumber = "502", RoomType = "Family Room", PricePerNight = 250.00m, IsAvailable = true, Capacity = 5 },
    new Room { RoomId = 14, HotelId = 6, RoomNumber = "601", RoomType = "Oceanfront Suite", PricePerNight = 600.00m, IsAvailable = true, Capacity = 3 },
    new Room { RoomId = 15, HotelId = 6, RoomNumber = "602", RoomType = "Standard", PricePerNight = 200.00m, IsAvailable = true, Capacity = 2 }
            );

            // Seed Guests
            modelBuilder.Entity<Guest>().HasData(
                new Guest { GuestId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890", CreatedAt = DateTime.Now },
                new Guest { GuestId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "987-654-3210", CreatedAt = DateTime.Now },
                new Guest { GuestId = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", PhoneNumber = "555-123-4567", CreatedAt = DateTime.Now },
    new Guest { GuestId = 4, FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com", PhoneNumber = "555-234-5678", CreatedAt = DateTime.Now },
    new Guest { GuestId = 5, FirstName = "David", LastName = "Martinez", Email = "david.martinez@example.com", PhoneNumber = "555-345-6789", CreatedAt = DateTime.Now },
    new Guest { GuestId = 6, FirstName = "Olivia", LastName = "Lopez", Email = "olivia.lopez@example.com", PhoneNumber = "555-456-7890", CreatedAt = DateTime.Now },
    new Guest { GuestId = 7, FirstName = "James", LastName = "Garcia", Email = "james.garcia@example.com", PhoneNumber = "555-567-8901", CreatedAt = DateTime.Now },
    new Guest { GuestId = 8, FirstName = "Sophia", LastName = "Harris", Email = "sophia.harris@example.com", PhoneNumber = "555-678-9012", CreatedAt = DateTime.Now },
    new Guest { GuestId = 9, FirstName = "William", LastName = "Brown", Email = "william.brown@example.com", PhoneNumber = "555-789-0123", CreatedAt = DateTime.Now },
    new Guest { GuestId = 10, FirstName = "Charlotte", LastName = "Clark", Email = "charlotte.clark@example.com", PhoneNumber = "555-890-1234", CreatedAt = DateTime.Now },
    new Guest { GuestId = 11, FirstName = "Benjamin", LastName = "Wilson", Email = "benjamin.wilson@example.com", PhoneNumber = "555-901-2345", CreatedAt = DateTime.Now },
    new Guest { GuestId = 12, FirstName = "Isabella", LastName = "Young", Email = "isabella.young@example.com", PhoneNumber = "555-012-3456", CreatedAt = DateTime.Now },
    new Guest { GuestId = 13, FirstName = "Lucas", LastName = "Allen", Email = "lucas.allen@example.com", PhoneNumber = "555-123-6789", CreatedAt = DateTime.Now },
    new Guest { GuestId = 14, FirstName = "Amelia", LastName = "Sanchez", Email = "amelia.sanchez@example.com", PhoneNumber = "555-234-8901", CreatedAt = DateTime.Now },
    new Guest { GuestId = 15, FirstName = "Ethan", LastName = "Thomas", Email = "ethan.thomas@example.com", PhoneNumber = "555-345-9012", CreatedAt = DateTime.Now }
            );

            // Seed Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    BookingId = 1,
                    GuestId = 1,
                    RoomId = 1,
                    CheckInDate = new DateTime(2025, 01, 15),
                    CheckOutDate = new DateTime(2025, 01, 20),
                    TotalAmount = 1500.00m,
                    BookingStatus = "Confirmed",
                    BookingDate = DateTime.Now
                },
                new Booking
                {
                    BookingId = 2,
                    GuestId = 2,
                    RoomId = 3,
                    CheckInDate = new DateTime(2025, 02, 10),
                    CheckOutDate = new DateTime(2025, 02, 15),
                    TotalAmount = 500.00m,
                    BookingStatus = "Confirmed",
                    BookingDate = DateTime.Now
                },
                new Booking { BookingId = 3, GuestId = 3, RoomId = 4, CheckInDate = DateTime.Now.AddDays(2), CheckOutDate = DateTime.Now.AddDays(7), BookingDate = DateTime.Now, TotalAmount = 1500.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 4, GuestId = 4, RoomId = 5, CheckInDate = DateTime.Now.AddDays(5), CheckOutDate = DateTime.Now.AddDays(10), BookingDate = DateTime.Now, TotalAmount = 1750.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 5, GuestId = 5, RoomId = 6, CheckInDate = DateTime.Now.AddDays(3), CheckOutDate = DateTime.Now.AddDays(8), BookingDate = DateTime.Now, TotalAmount = 1200.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 6, GuestId = 6, RoomId = 7, CheckInDate = DateTime.Now.AddDays(1), CheckOutDate = DateTime.Now.AddDays(6), BookingDate = DateTime.Now, TotalAmount = 1100.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 7, GuestId = 7, RoomId = 8, CheckInDate = DateTime.Now.AddDays(7), CheckOutDate = DateTime.Now.AddDays(12), BookingDate = DateTime.Now, TotalAmount = 1300.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 8, GuestId = 8, RoomId = 9, CheckInDate = DateTime.Now.AddDays(4), CheckOutDate = DateTime.Now.AddDays(9), BookingDate = DateTime.Now, TotalAmount = 1400.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 9, GuestId = 9, RoomId = 10, CheckInDate = DateTime.Now.AddDays(2), CheckOutDate = DateTime.Now.AddDays(7), BookingDate = DateTime.Now, TotalAmount = 1600.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 10, GuestId = 10, RoomId = 11, CheckInDate = DateTime.Now.AddDays(3), CheckOutDate = DateTime.Now.AddDays(8), BookingDate = DateTime.Now, TotalAmount = 1900.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 11, GuestId = 11, RoomId = 12, CheckInDate = DateTime.Now.AddDays(6), CheckOutDate = DateTime.Now.AddDays(11), BookingDate = DateTime.Now, TotalAmount = 2100.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 12, GuestId = 12, RoomId = 13, CheckInDate = DateTime.Now.AddDays(1), CheckOutDate = DateTime.Now.AddDays(6), BookingDate = DateTime.Now, TotalAmount = 1800.00m , BookingStatus = "Confirmed" },
    new Booking { BookingId = 13, GuestId = 13, RoomId = 14, CheckInDate = DateTime.Now.AddDays(2), CheckOutDate = DateTime.Now.AddDays(7), BookingDate = DateTime.Now, TotalAmount = 2200.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 14, GuestId = 14, RoomId = 15, CheckInDate = DateTime.Now.AddDays(3), CheckOutDate = DateTime.Now.AddDays(8), BookingDate = DateTime.Now, TotalAmount = 2500.00m, BookingStatus = "Confirmed" },
    new Booking { BookingId = 15, GuestId = 15, RoomId = 4, CheckInDate = DateTime.Now.AddDays(5), CheckOutDate = DateTime.Now.AddDays(10), BookingDate = DateTime.Now, TotalAmount = 1600.00m, BookingStatus = "Confirmed" }
            );

            // Seed Payments
            modelBuilder.Entity<Payment>().HasData(
                new Payment { PaymentId = 1, BookingId = 1, PaymentDate = DateTime.Now, Amount = 1500.00m, PaymentMethod = "Credit Card", PaymentStatus = "Paid" },
                new Payment { PaymentId = 2, BookingId = 2, PaymentDate = DateTime.Now, Amount = 500.00m, PaymentMethod = "Cash", PaymentStatus = "Paid" },
                new Payment { PaymentId = 3, BookingId = 3, PaymentDate = DateTime.Now.AddDays(1), Amount = 1500.00m, PaymentMethod = "Credit Card", PaymentStatus = "Completed" },
    new Payment { PaymentId = 4, BookingId = 4, PaymentDate = DateTime.Now.AddDays(2), Amount = 1750.00m, PaymentMethod = "Debit Card", PaymentStatus = "Completed" },
    new Payment { PaymentId = 5, BookingId = 5, PaymentDate = DateTime.Now.AddDays(1), Amount = 1200.00m, PaymentMethod = "PayPal", PaymentStatus = "Completed" },
    new Payment { PaymentId = 6, BookingId = 6, PaymentDate = DateTime.Now.AddDays(3), Amount = 1100.00m, PaymentMethod = "Credit Card", PaymentStatus = "Completed" },
    new Payment { PaymentId = 7, BookingId = 7, PaymentDate = DateTime.Now.AddDays(1), Amount = 1300.00m, PaymentMethod = "Credit Card", PaymentStatus = "Completed" },
    new Payment { PaymentId = 8, BookingId = 8, PaymentDate = DateTime.Now.AddDays(2), Amount = 1400.00m, PaymentMethod = "Debit Card", PaymentStatus = "Completed" },
    new Payment { PaymentId = 9, BookingId = 9, PaymentDate = DateTime.Now.AddDays(1), Amount = 1600.00m, PaymentMethod = "Credit Card", PaymentStatus = "Pending" },
    new Payment { PaymentId = 10, BookingId = 10, PaymentDate = DateTime.Now.AddDays(3), Amount = 1900.00m, PaymentMethod = "PayPal", PaymentStatus = "Completed" },
    new Payment { PaymentId = 11, BookingId = 11, PaymentDate = DateTime.Now.AddDays(2), Amount = 2100.00m, PaymentMethod = "Bank Transfer", PaymentStatus = "Completed" },
    new Payment { PaymentId = 12, BookingId = 12, PaymentDate = DateTime.Now.AddDays(1), Amount = 1800.00m, PaymentMethod = "Debit Card", PaymentStatus = "Completed" },
    new Payment { PaymentId = 13, BookingId = 13, PaymentDate = DateTime.Now.AddDays(2), Amount = 2200.00m, PaymentMethod = "Credit Card", PaymentStatus = "Completed" },
    new Payment { PaymentId = 14, BookingId = 14, PaymentDate = DateTime.Now.AddDays(1), Amount = 2500.00m, PaymentMethod = "PayPal", PaymentStatus = "Completed" },
    new Payment { PaymentId = 15, BookingId = 15, PaymentDate = DateTime.Now.AddDays(3), Amount = 1600.00m, PaymentMethod = "Bank Transfer", PaymentStatus = "Pending" }
            );
        }
    }
}
