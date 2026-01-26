using System.Reflection;
using Api.Routes.Web;

namespace Api.Routes;
/// <summary>
/// Extension methods to map HTTP endpoints.
/// </summary>
public static class Mapping
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/", async ()  => "Hello, World!");
        app.MapEndpoint<SettingsEndpoint>();
    }

    public static void MapEndpoint<TEndpoint>(this WebApplication app)
        where TEndpoint : IEndpoint
    {
    }

    public static void MapEndpoints(this WebApplication app, params Assembly[] assemblies)
    {
    }
}