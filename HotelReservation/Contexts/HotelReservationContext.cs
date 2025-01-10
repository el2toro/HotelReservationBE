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

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}
