using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace HotelReservation.Services;

public interface ITwilioService
{
    Task<string> SmsSend(string toNumber, string message);
}
public class TwilioService(IConfiguration configuration,
    ILogger<TwilioService> logger) : ITwilioService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<TwilioService> _logger = logger;

    public async Task<string> SmsSend(string toNumber, string message)
    {
        var accountSid = _configuration["Twilio:AccountSid"];
        var authToken = _configuration["Twilio:AuthToken"];
        var fromNumber = _configuration["Twilio:FromNumber"];

        TwilioClient.Init(accountSid, authToken);

        try
        {
            var response = await MessageResource.CreateAsync(
            body: message,
            from: new Twilio.Types.PhoneNumber(fromNumber),
            to: new Twilio.Types.PhoneNumber(toNumber));

            return response.Body;
        }
        catch (Exception ex)
        {
            _logger.LogError("Something went wrong while trying to send sms", ex);
            throw;
        }
    }
}
