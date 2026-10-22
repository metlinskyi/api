namespace Self.Api.Middleware.Events;

public class EventBusOptions<T>
{
    public T Settings {get;set;} = default!;
}