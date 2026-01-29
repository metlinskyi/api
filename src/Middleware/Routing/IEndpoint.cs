namespace Api.Middleware.Routing;

/// <summary>
/// Marker interface for endpoints.
/// </summary>
public interface IEndpoint
{
}

public interface IEndpoint<TMethod> : IEndpoint
    where TMethod : IHttpMethod
{
    public TMethod Method { get; }
}

