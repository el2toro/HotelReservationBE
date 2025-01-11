namespace HotelReservation.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int PricePerNight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Rating { get; set; }
        public Location Location { get; set; }
        public Amenities Amenities { get; set; }
    }

    public class Location
    {
        public int LocationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
    }

    public class Amenities
    {
        public int AmenitiesId { get; set; }
        public bool HasInternet { get; set; }
        public bool HasPrivateParking { get; set; }
        public bool HasRoomService { get; set; }
        public bool HasFrontDesck24 { get; set; }
        public bool HasFitenssCenter { get; set; }
        public bool HasSPA { get; set; }
        public bool HasNetflix { get; set; }
        public bool HasSmokingArea { get; set; }
        public bool HasNoSmokingRooms { get; set; }
        public bool HasGameRoom { get; set; }
        public bool HasPoolParkour { get; set; }
        public bool HasVideoGames { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasBbq { get; set; }
        public bool HasSaturdayNight { get; set; }
        public bool HasSwimmingPool{ get; set; }
        public bool PetsAllowed { get; set; }
        public bool HasCurencyExcenge { get; set; }
        public bool HasLounge { get; set; }
        public bool HasMiniBar { get; set; }
    }
}
