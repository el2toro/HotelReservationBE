namespace HotelReservation.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Rating { get; set; }

        // Navigation Properties
        public Location Location { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<HotelAmenity> HotelAmenities { get; set; }
    }
}
