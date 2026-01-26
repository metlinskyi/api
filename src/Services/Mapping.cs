namespace Api.Services;
/// <summary>
/// Extension methods to map gRPC services.
/// </summary>
public static class Mapping
{
    public static void MapServices(this WebApplication app)
    {
        app.MapGrpcService<GreeterService>();
        app.MapGrpcService<UploadService>();
        app.MapGrpcReflectionService();
    }
}