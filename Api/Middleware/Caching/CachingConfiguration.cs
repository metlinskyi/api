namespace Self.Api.Middleware.Caching;

internal static class CachingConfiguration
{
    public static void ConfigureCachingOptions<T>(this IServiceCollection services, Action<CachingOptions<T>> options)
        where T : new()
    {
        var _ = new CachingOptions<T>();
        options.Invoke(_);
    }
}