namespace Api.Middleware.Routing;

/// <summary>
/// Marker interface for HTTP methods.
/// </summary>
public interface IHttpMethod
{
}

public interface IHttpGet : IHttpMethod
{
}

public interface IHttpPost : IHttpMethod
{
}