using RabbitMQ.Client;
using System.Text;

namespace HotelReservation.RabbitMQ;

public interface IRabbitMQService
{
    Task SendNotification(string message);
}
public class RabbitMQService : IRabbitMQService
{
    public async Task SendNotification(string message)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };

        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        // await channel.ExchangeDeclareAsync(exchange: "bookings", type: ExchangeType.Fanout);

        // Declare a queue
        //await channel.QueueDeclareAsync(queue: "booking_queue",
        //                     durable: false,
        //                     exclusive: false,
        //                     autoDelete: false,
        //                     arguments: null);

        var body = Encoding.UTF8.GetBytes(message);
        await channel.BasicPublishAsync(exchange: "", routingKey: "booking_queue", body: body);
    }
}
