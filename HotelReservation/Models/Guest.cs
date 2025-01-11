namespace HotelReservation.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public ICollection<Booking> Bookings { get; set; }
    }
}
