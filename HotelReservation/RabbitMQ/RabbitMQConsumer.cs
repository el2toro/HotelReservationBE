using HotelReservation.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace HotelReservation.RabbitMQ;

public interface IRabbitMQConsumer
{
    Task StartConsuming();
}
public class RabbitMQConsumer(IEmailSendService emailSendService,
    ITwilioService twilioService,
    IConfiguration configuration,
    ILogger<RabbitMQConsumer> logger) : IRabbitMQConsumer
{
    private readonly IEmailSendService _emailSendService = emailSendService;
    private readonly ITwilioService _twilioService = twilioService;
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<RabbitMQConsumer> _logger = logger;

    public async Task StartConsuming()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: "booking_queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += (model, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            string twilioToNumber = _configuration["Twilio:ToNumber"];

            _emailSendService.SendEmail(message);
            _twilioService.SmsSend(twilioToNumber, message);

            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync(queue: "booking_queue", autoAck: true, consumer: consumer);
    }
}
