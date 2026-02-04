using System.Linq.Expressions;

namespace Api.Middleware.Routing;

public static class Mapper
{
    public static Endpoint MapEndpoint<TService>(this WebApplication app, Expression<Func<TService, Delegate>> delegateFactory)
        where TService : notnull
    {
        return new ServiceEndpoint<TService>(app, delegateFactory);
    }

    public static Endpoint MapEndpoint<TRequest>(this WebApplication app)
        where TRequest : IBaseRequest
    {
       return new MediatorEndpoint<TRequest>(app);
    }

    public static void AddEndpointMapping(this IServiceCollection services, Action<EndpointMapper> configure)
    {
        services.AddSingleton(sp =>
        {
            var mapper = new EndpointMapper(sp.GetRequiredService<ILogger<EndpointMapper>>());
            configure(mapper);
            return mapper;
        });
    }
}