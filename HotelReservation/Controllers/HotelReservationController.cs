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
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Hotel>> GetByIdAsync(int hotelId)
        {
            var result = await _repository.GetByIdAsync(hotelId);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync(Hotel hotel)
        {
            await _repository.UpdateAsync(hotel);
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreteAsync(Hotel hotel)
        {
            await _repository.CreateAsync(hotel);
            return Ok(HttpStatusCode.Created);
        }

        //TODO: 
        [HttpPost("Load")]
        public async Task<ActionResult> LoadAsync(Hotel hotel)
        {
            await _repository.CreateAsync(hotel);
            return Ok(HttpStatusCode.Accepted);
        }

        //TODO: 
        [HttpPost("GetByRegion")]
        public async Task<ActionResult> GetByRegionAsync(string destination)
        {
            //await _repository.CreateAsync(hotel);
            return Ok(HttpStatusCode.Accepted);
        }
    }
}
