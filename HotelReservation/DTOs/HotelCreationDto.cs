namespace HotelReservation.DTOs
{
    public class HotelCreationDto
    {
        public string WhereToGo { get; set; }
        public string CheckIn { get; set; }
        public string Checkout { get; set; }
        public int Rooms { get; set; }
        public int Guests { get; set; }
    }
}
