using Microsoft.EntityFrameworkCore;
using Self.Data.Access;

namespace Self.Api.Middleware.Caching;

internal static class CachingConfiguration
{
    public static void ConfigureCachingOptions(this IServiceCollection services, Action<CachingOptions> options)
    {
    }
}