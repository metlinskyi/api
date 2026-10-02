using Microsoft.AspNetCore.Http.HttpResults;

namespace Self.Api.Auth;
/// <summary>
/// Endpoints for authentication
/// </summary>
internal static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication webApp, RouteGroupBuilder root, int version)
    {
        var auth = root.MapGroup("/auth");

        auth.MapPut("/", () => {})
            .WithName("Authenticate");
    }
}