namespace Api.Middleware.Routing;

/// <summary>
/// Marker interface for endpoints.
/// </summary>
public interface IEndpoint
{
}

public interface IEndpoint<TResponse> : IEndpoint
{
    Task<TResponse> Handler();
}

public interface IEndpoint<TRequest,TResponse> : IEndpoint
{
    Task<TResponse> Handler(TRequest request);
}
