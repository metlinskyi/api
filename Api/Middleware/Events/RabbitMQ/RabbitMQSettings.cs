namespace Self.Api.Middleware.Events.RabbitMQ;

public class RabbitMQSettings
{
    public string UserName {get;set;} = default!;
    public string Password {get;set;} = default!;
    public string HostName {get;set;} = default!;
    public string VirtualHost {get;set;} = default!;
}