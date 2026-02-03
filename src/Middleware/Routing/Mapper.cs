namespace Api.Middleware.Routing;

public static class Mapper
{
    public static Endpoint MapServiceEndpoint<TService>(this WebApplication app, Func<TService, Delegate> delegateFactory)
        where TService : notnull
    {
        return new ServiceEndpoint<TService>(app, delegateFactory);
    }

    public static Endpoint MapMediatorEndpoint<TRequest>(this WebApplication app)
        where TRequest : IBaseRequest
    {
       return new MediatorEndpoint<TRequest>(app);
    }

    public static void AddEndpointMapping(this IServiceCollection services, Action<EndpointMapper> configure)
    {
        services.AddSingleton(sp =>
        {
            var mapper = new EndpointMapper();
            configure(mapper);
            return mapper;
        });
    }
}