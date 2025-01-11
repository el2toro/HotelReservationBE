using HotelReservation.Contexts;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repository
{
    public interface IHotelReservationRepository
    {
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(int id);
        Task UpdateAsync(Hotel hotel);
        Task CreateAsync(Hotel hotel);
        Task DeleteAsync(int id);
        Task<IEnumerable<Hotel>> GetRegionsAsync(string destination);
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
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                throw new InvalidOperationException($"Hotel with id: {id} wasn't found");

             _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            var hotels = await _context.Hotels
                .Include(h => h.Location)
                .ToListAsync();

            return hotels;
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Location)
                .FirstOrDefaultAsync(h => h.HotelId == id);

            return hotel;
        } 

        public async Task UpdateAsync(Hotel hotel)
        {
            var hotelToUpdate = await _context.Hotels
                .Include(h => h.Location)
                .FirstOrDefaultAsync(h => h.HotelId == hotel.HotelId);

            if (hotelToUpdate == null)
                throw new InvalidOperationException($"An error occurred while trying to update hotel with id: { hotel.HotelId }");

            hotelToUpdate.Name = hotel.Name;
            hotelToUpdate.Location = hotel.Location;
            hotelToUpdate.Description = hotel.Description;
            
            _context.Update(hotelToUpdate);
            await _context.SaveChangesAsync(); 
        }

        public Task<IEnumerable<Hotel>> GetRegionsAsync(string destination)
        {
            throw new NotImplementedException();
        }
    }
}
