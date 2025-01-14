using HotelReservation.Stripe.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;

namespace HotelReservation.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CheckoutController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CheckoutController> _logger;
        public CheckoutController(IConfiguration configuration, ILogger<CheckoutController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        //TODO
        [HttpPost("CreateCheckoutSession")]
        public ActionResult CreateCheckoutSession(Checkout checkout)
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
                             Currency = checkout.Currency,
                             ProductData = new SessionLineItemPriceDataProductDataOptions
                             {
                                 Name = checkout.ProductName,
                                 Description = checkout.ProductDescription,
                             },
                             UnitAmount = checkout.Amount
                         },
                         Quantity = checkout.Quantity,
                     },
                 },
                Mode = "payment",
                SuccessUrl = checkout.SuccessUrl,
                CancelUrl = checkout.CancelUrl,
            };


            try
            {
                var service = new SessionService();
                var session = service.Create(options);

                return Ok(new CheckoutResponse { SessionId = session.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong while trying to create checkout session", ex);
                throw;
            }
        }
    }
}
