namespace Api.Middleware.Routing;

public class ServiceEndpoint<TService> : Endpoint
    where TService : notnull
{
    public ServiceEndpoint(WebApplication app, Func<TService, Delegate> delegateFactory) : base(app, typeof(TService))
    {
        Delegate = async (context) =>
        {   
            Logger.LogInformation("Handling service request: {RequestType}", Type.Name);

            var service = context.RequestServices.GetRequiredService<TService>();
            var del = delegateFactory(service);
            var response = await (Task<object?>)del.DynamicInvoke(context)!;
            if (response == null)
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return;
            }

            await context.Response.WriteAsJsonAsync(response, response.GetType(), AppJsonSerializerContext.Default);
        };
    }
}