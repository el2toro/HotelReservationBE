﻿using HotelReservation.DTOs;
using HotelReservation.Extentions;
using HotelReservation.Models;
using HotelReservation.Repository;
using HotelReservation.Stripe.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Net;

namespace HotelReservation.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class HotelReservationController : Controller
    {
        private readonly IHotelReservationRepository _repository;
        private readonly IConfiguration _configuration;
        public HotelReservationController(IHotelReservationRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
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

        //TODO
        [HttpPost("CheckOut")]
        public async Task<ActionResult> CheckOutAsync(CheckOutModel checkOutModel)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                 {
                     new SessionLineItemOptions
                     {
                         PriceData = new SessionLineItemPriceDataOptions
                         {
                             Currency = checkOutModel.Currency,
                             ProductData = new SessionLineItemPriceDataProductDataOptions
                             {
                                 Name = checkOutModel.ProductName,
                                 Description = checkOutModel.ProductDescription,
                             },
                             UnitAmount = checkOutModel.Amount
                         },
                         Quantity = checkOutModel.Quantity,
                     },
                 },
                Mode = "payment",
                SuccessUrl = checkOutModel.SuccessUrl,
                CancelUrl = checkOutModel.CancelUrl,
            };



            try
            {
                var service = new SessionService();
                var session = service.Create(options);

                return Ok(new { sessionId = session.Id });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
