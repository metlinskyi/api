namespace Api.Routes;

using Bot;
using Web;

/// <summary>
/// Extension methods to map HTTP endpoints.
/// </summary>
public static class Mapping
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapMediatorEndpoint<SettingsRequest>().AsPost();
        app.MapMediatorEndpoint<ImageOfTheDayRequest>().AsGet();
    }
}    