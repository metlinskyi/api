
namespace Api.Routes;
/// <summary>
/// Base class for defining HTTP endpoints.
/// </summary>
/// 
public interface IEndpoint
{

}

public interface IEndpoint<TRequest, TResponse> : IEndpoint
    where TRequest : IRequest
{
    Task<TResponse> HandleAsync(TRequest request);
}

public interface IRequest
{
}

public class GetRequest<TRequestModel> : IRequest
{
}
public class GetRequest : IRequest
{
}

public abstract class Endpoint<TRequest, TResponse> : IEndpoint
{
    public abstract Task<TResponse> HandleAsync(TRequest request);
}

public abstract class Endpoint : Endpoint<object, object>
{   

}