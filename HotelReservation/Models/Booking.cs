namespace HotelReservation.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Guest Guest { get; set; }
        public Room Room { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
