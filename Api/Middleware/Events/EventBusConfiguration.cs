namespace Self.Api.Middleware.Events;

internal static class EventBusConfiguration
{
    public static void ConfigureEventBusOptions<T>(this IServiceCollection services, Action<EventBusOptions<T>> options) 
        where T : new()
    {
        var _ = new EventBusOptions<T>();
        options.Invoke(_);
    }
}