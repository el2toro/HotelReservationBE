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
        }
    }
}
