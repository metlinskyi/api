using RabbitMQ.Client;

namespace Self.Api.Middleware.Events.RabbitMQ;

public class RabbitMQEventBus 
{
    ConnectionFactory factory = null!;
    IChannel channel  = null!;
    IConnection conn = null!;

    public RabbitMQEventBus(RabbitMQSettings settings)
    {
        
        factory = new()
        {
            UserName = settings.UserName,
            Password = settings.Password,
            VirtualHost = settings.VirtualHost,
            HostName = settings.HostName
        };
    }

    public async Task CloseAsync()
    {
        await channel.CloseAsync();
        await conn.CloseAsync();
        await channel.DisposeAsync();
        await conn.DisposeAsync();
    }


    public async Task<IChannel> Channel()
    {
        if(channel == null)
        {
            IConnection conn = await factory.CreateConnectionAsync();
            channel = await conn.CreateChannelAsync();
        }

        return channel;
    }


    public async ValueTask PublishingMessages(string exchangeName, string routingKey, string msg)
    {
        byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(msg);
        var properties = new BasicProperties
        {
            ContentType = "application/json"
        };

        await Channel().Result.BasicPublishAsync(exchangeName, routingKey, false, properties, messageBodyBytes);
    }
}