namespace HotelReservation.Models
{
    public class Amenity
    {
        public int AmenityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Property
        public ICollection<HotelAmenity> HotelAmenities { get; set; }
    }
}
