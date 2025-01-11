namespace HotelReservation.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int Capacity { get; set; }

        // Navigation Property
        public Hotel Hotel { get; set; }
    }
}
