using HotelReservation.DTOs;
using HotelReservation.Models;
using HotelReservation.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelReservation.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class HotelReservationController : Controller
    {
        private readonly IHotelReservationRepository _repository;
        public HotelReservationController(IHotelReservationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<HotelDto>> GetByIdAsync(int hotelId)
        {
            var result = await _repository.GetByIdAsync(hotelId);
            return Ok(result);
        }

        // TODO
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync(Hotel hotel)
        {
            await _repository.UpdateAsync(hotel);
            return Ok();
        }

        //TODO
        [HttpPost("Create")]
        public async Task<ActionResult> CreteAsync(Hotel hotel)
        {
            await _repository.CreateAsync(hotel);
            return Ok(HttpStatusCode.Created);
        }

        //TODO
        [HttpGet("GetRooms")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomsAsync(int hotelId)
        {
            var rooms = await _repository.GetRooms(hotelId);
            return Ok(rooms);
        }

        //TODO
        [HttpGet("GetAmenities")]
        public async Task<ActionResult<IEnumerable<AmenityDto>>> GetAmenitiesAsync(int hotelId)
        {
            var amenities = await _repository.GetAmenities(hotelId);
            return Ok(amenities);
        }

        //TODO
        [HttpGet("BookRoom")]
        public async Task<ActionResult> BookRoomAsync()
        {
            //var amenities = await _repository.GetAmenities(hotelId);
            return Ok();
        }
    }
}
