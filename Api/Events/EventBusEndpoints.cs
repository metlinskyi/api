using Microsoft.AspNetCore.Http.HttpResults;

namespace Self.Api.Events;
/// <summary>
/// Endpoints for authentication
/// </summary>
internal static class EventBusEndpoints
{
    public static void MapEventBusEndpoints(this WebApplication webApp, RouteGroupBuilder root, int version)
    {
        var auth = root.MapGroup("/events");

        auth.MapPut("/", () => {})
            .WithName("Authenticate");
    }
}