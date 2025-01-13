namespace HotelReservation.DTOs
{
    public class BookingDto
    {
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string BookingStatus { get; set; }
        public string BookingDate { get; set; }
    }
}
