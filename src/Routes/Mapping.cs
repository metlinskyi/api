namespace Api.Routes;

using Web;

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
}