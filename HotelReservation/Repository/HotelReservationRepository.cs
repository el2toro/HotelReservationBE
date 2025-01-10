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
        Task<IEnumerable<Destination>> GetByRegionAsync(string destination);
        Task<IEnumerable<Hotel>> GetRegionsAsync(string destination);
        Task<IEnumerable<Destination>> GetDestinationsAsync(string destination);
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
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);

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
                .FirstOrDefaultAsync(h => h.Id == id);

            return hotel;
        } 

        public async Task UpdateAsync(Hotel hotel)
        {
            var hotelToUpdate = await _context.Hotels
                .Include(h => h.Location)
                .FirstOrDefaultAsync(h => h.Id == hotel.Id);

            if (hotelToUpdate == null)
                throw new InvalidOperationException($"An error occurred while trying to update hotel with id: { hotel.Id }");

            hotelToUpdate.Name = hotel.Name;
            hotelToUpdate.Location = hotel.Location;
            hotelToUpdate.Description = hotel.Description;
            
            _context.Update(hotelToUpdate);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Destination>> GetByRegionAsync(string destination)
        {
            //TODO
            var destinations =  _context.Destinations.Where(d => d.City == destination).ToArray();

            return destinations;
        }

        public Task<IEnumerable<Hotel>> GetRegionsAsync(string destination)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Destination>> GetDestinationsAsync(string? destination)
        {
            if (string.IsNullOrEmpty(destination))
            {
                return await _context.Destinations.Take(5).ToListAsync();
            }

            return await _context.Destinations.ToListAsync();
        }
    }
}
