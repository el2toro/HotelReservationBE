using HotelReservation.DTOs;
using HotelReservation.Extentions;
using HotelReservation.Models;
using HotelReservation.RabbitMQ;
using HotelReservation.Repository;
using HotelReservation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelReservation.Controllers;

[ApiController]
[Route("[controller]/")]
public class HotelReservationController(IHotelReservationRepository repository,
    IConfiguration configuration,
    IRabbitMQService rabbitMQService,
    IRabbitMQConsumer rabbitMQConsumer,
    IEmailSendService emailSendService) : Controller
{
    private readonly IHotelReservationRepository _repository = repository;
    private readonly IConfiguration _configuration = configuration;
    private readonly IRabbitMQService _rabbitMQService = rabbitMQService;
    private readonly IRabbitMQConsumer _rabbitMQConsumer = rabbitMQConsumer;
    private readonly IEmailSendService _emailSendService = emailSendService;

    [HttpPost("GetAll")]
    public async Task<ActionResult<IEnumerable<HotelDto>>> GetAllAsync([FromBody] HotelSearchDto searchDto)
    {
        var result = await _repository.GetAllAsync(searchDto);
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
    [HttpPost("BookRoom")]
    public async Task<ActionResult> BookRoomAsync(BookingDto booking)
    {
        await _repository.BookRoom(booking);
        return Ok();
    }

    //TODO
    [HttpGet("GetReservationPrice")]
    public async Task<ActionResult> GetReservationPriceAsync(int roomId)
    {
        var price = await _repository.GetReservationPrice(roomId);
        return Ok(price);
    }


    //TODO
    [HttpGet("CheckRoomAvailability")]
    public async Task<ActionResult> CheckRoomAvailabilityAsync(int roomId, string checkInDate, string checkOutDate)
    {
        var isAvailable = await _repository.CheckRoomAvailability(roomId, checkInDate.ToDateTime(), checkOutDate.ToDateTime());
        return Ok(isAvailable);
    }

    [HttpGet("GetLocations")]
    public async Task<ActionResult> CheckRoomAvaiGetLocationslabilityAsync()
    {
        var locations = await _repository.GetLocations();
        return Ok(locations);
    }

    //TODO
    [HttpGet("RabbitMQSend")]
    public async Task<ActionResult> RabbitMQSend()
    {
        // await Task.Run(() => _rabbitMQConsumer.StartConsuming());

        await _rabbitMQService.SendNotification("Message sent via rabbit mq");
        return Ok();
    }

    //TODO
    [HttpGet("RabbitMQStartConsuming")]
    public async Task<ActionResult> RabbitMQStartConsuming()
    {
        await Task.Run(() => _rabbitMQConsumer.StartConsuming());
        return Ok();
    }

    //TODO
    [HttpGet("SendEmail")]
    public async Task<ActionResult> SendEmail()
    {
        _emailSendService.SendEmail("");
        return Ok();
    }
}
