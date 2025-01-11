namespace HotelReservation.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }      
        public string PostalCode { get; set; }

        // Navigation Property
        public ICollection<Hotel> Hotels { get; set; }
    }
}
