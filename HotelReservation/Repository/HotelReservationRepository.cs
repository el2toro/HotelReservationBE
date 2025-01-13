using HotelReservation.Contexts;
using HotelReservation.DTOs;
using HotelReservation.Extentions;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repository
{
    public interface IHotelReservationRepository
    {
        Task<IEnumerable<HotelDto>> GetAllAsync();
        Task<HotelDto> GetByIdAsync(int id);
        Task UpdateAsync(Hotel hotel);
        Task CreateAsync(Hotel hotel);
        Task DeleteAsync(int id);
        Task<IEnumerable<RoomDto>> GetRooms(int hotelId);
        Task<IEnumerable<AmenityDto>> GetAmenities(int hotelId);
        Task BookRoom(BookingDto bookingDto);
        Task<decimal> GetReservationPrice(int roomId);
        Task<bool> CheckRoomAvailability(int roomId, DateTime checkInDate, DateTime checkOutDate);
    }
    public class HotelReservationRepository : IHotelReservationRepository
    {
        private readonly HotelReservationContext _context;
        public HotelReservationRepository(HotelReservationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(h => h.HotelId == id) ?? throw new InvalidOperationException($"Hotel with id: {id} wasn't found");

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelDto>> GetAllAsync()
        {
            var hotels = await _context.Hotels
                .Include(h => h.Location)
                .Select(h => new HotelDto
                {
                    // TODO: add starting room price
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Description = h.Description,
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt,
                    IsAvailable = h.IsAvailable,
                    Rating = h.Rating,
                    Location = new LocationDto
                    {
                        Address = h.Location.Address,
                        City = h.Location.City,
                        State = h.Location.State,
                        PostalCode = h.Location.PostalCode,
                        Country = h.Location.Country
                    }

                }).ToListAsync();

            return hotels;
        }

        public async Task<HotelDto> GetByIdAsync(int id)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Location)
                .Select(h => new HotelDto
                {
                    // TODO: add starting room price
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Description = h.Description,
                    CreatedAt = h.CreatedAt,
                    UpdatedAt = h.UpdatedAt,
                    IsAvailable = h.IsAvailable,
                    Rating = h.Rating,
                    Location = new LocationDto
                    {
                        Address = h.Location.Address,
                        City = h.Location.City,
                        State = h.Location.State,
                        PostalCode = h.Location.PostalCode,
                        Country = h.Location.Country
                    }
                }).FirstOrDefaultAsync(h => h.HotelId == id);

            return hotel;
        }

        public async Task UpdateAsync(Hotel hotel)
        {
            var hotelToUpdate = await _context.Hotels
                .Include(h => h.Location)
                .FirstOrDefaultAsync(h => h.HotelId == hotel.HotelId) ?? throw new InvalidOperationException($"An error occurred while trying to update hotel with id: {hotel.HotelId}");

            hotelToUpdate.Name = hotel.Name;
            hotelToUpdate.Location = hotel.Location;
            hotelToUpdate.Description = hotel.Description;

            _context.Update(hotelToUpdate);
            await _context.SaveChangesAsync();
        }

        // TODO: Apply filters
        public async Task<IEnumerable<RoomDto>> GetRooms(int hotelId)
        {
            var rooms = await _context.Rooms
                .Where(room => room.HotelId == hotelId)
                .Select(room => new RoomDto
                {
                    HotelId = room.HotelId,
                    Capacity = room.Capacity,
                    IsAvailable = room.IsAvailable,
                    PricePerNight = room.PricePerNight,
                    RoomId = room.RoomId,
                    RoomNumber = room.RoomNumber,
                    RoomType = room.RoomType
                }).ToListAsync();

            return rooms;
        }

        // TODO: Apply filters
        public async Task<IEnumerable<AmenityDto>> GetAmenities(int hotelId)
        {
            var amenities = await _context.HotelAmenities
                .Where(amenity => amenity.HotelId == hotelId)
                .Select(amenity => new AmenityDto
                {
                    Name = amenity.Amenity.Name,
                    Description = amenity.Amenity.Description
                }).ToListAsync();

            return amenities;
        }

        // TODO: Apply filters
        public async Task BookRoom(BookingDto bookingDto)
        {
            var bookind = new Booking
            {
                GuestId = bookingDto.GuestId,
                RoomId = bookingDto.RoomId,
                BookingDate = DateTime.Now,
                BookingStatus = bookingDto.BookingStatus,
                CheckInDate = bookingDto.CheckInDate.ToDateTime(),
                CheckOutDate = bookingDto.CheckOutDate.ToDateTime(),
                TotalAmount = bookingDto.TotalAmount
            };

            try
            {
                // TODO: check room availability on those dates
                // 2. update room availability after adding new booking
                // 3. send an email/sms on successfull booking via RabbitMQ?
                await _context.Bookings.AddAsync(bookind);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO: Log error
                throw;
            }
        }

        // TODO: Apply filters
        public async Task<decimal> GetReservationPrice(int roomId)
        {
            var room = await _context.Rooms
                .SingleOrDefaultAsync(room => room.RoomId == roomId);

            return room.PricePerNight * 2;
        }

        // TODO: Apply
        // 2. DateOnly?
        public async Task<bool> CheckRoomAvailability(int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            var booking = await _context.Bookings
                .Where(booking => booking.RoomId == roomId && (booking.CheckInDate >= checkInDate && booking.CheckOutDate <= checkOutDate))
                .FirstOrDefaultAsync();

            if (booking != null)
            {
                var room = await _context.Rooms.SingleOrDefaultAsync(room => room.RoomId == roomId);
                room.IsAvailable = false;
                _context.SaveChanges();

                return false;
            }

            return true;
        }
    }
}
