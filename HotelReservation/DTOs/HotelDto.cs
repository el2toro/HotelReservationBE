namespace HotelReservation.DTOs
{
    public class HotelDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsAvailable { get; set; }
        public int Rating { get; set; }
        public LocationDto Location { get; set; }
    }
}
