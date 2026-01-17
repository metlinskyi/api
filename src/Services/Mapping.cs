namespace Api.Services;
public static class Mapping
{
    public static void MapServices(this WebApplication app)
    {
        app.MapGrpcService<GreeterService>();
        app.MapGrpcService<ImageService>();
        app.MapGrpcReflectionService();
    }
}