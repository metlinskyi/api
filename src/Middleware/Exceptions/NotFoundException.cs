namespace Api.Middleware.Routing;
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}