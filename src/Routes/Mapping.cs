namespace Api.Routes;
public static class Mapping
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Hello, World!");
    }
}