namespace HotelReservation.DTOs
{
    public class HotelSearchDto
    {
        public string? WhereToGo { get; set; }
        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }
        public int? Rooms { get; set; }
        public int? Guests { get; set; }
    }
}
