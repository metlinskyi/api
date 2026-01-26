using System.Reflection;

namespace Api.Middleware.Routing;

public static class Mapper
{
    public static void MapEndpoint<TEndpoint>(this WebApplication app)
        where TEndpoint : IEndpoint
    {
    }

    public static void MapEndpoints(this WebApplication app, params Assembly[] assemblies)
    {
    }
}