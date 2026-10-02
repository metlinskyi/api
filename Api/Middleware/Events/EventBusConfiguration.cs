namespace Self.Api.Middleware.Events;

internal static class EventBusConfiguration
{
    private static EventBusOptions Options = new();
    public static void ConfigureEventBusOptions(this IServiceCollection services, Action<EventBusOptions> options)
    {
        options.Invoke(Options);
    }
}