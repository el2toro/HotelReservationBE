namespace HotelReservation.Stripe.Models
{
    public class Checkout
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public long Amount { get; set; }
        public string? Currency { get; set; }
        public long Quantity { get; set; }
        public string? SuccessUrl { get; set; }
        public string? CancelUrl { get; set; }
    }
}
