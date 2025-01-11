namespace HotelReservation.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // e.g. credit card, cash, online
        public string PaymentStatus { get; set; } // e.g. paid, pending, failed

        // Navigation Propertie
        public Booking Booking { get; set; }
    }
}
