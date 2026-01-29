namespace Api.Middleware.Routing;

public class MediatorEndpoint<TRequest> : Endpoint
    where TRequest : IBaseRequest
{
    public MediatorEndpoint(WebApplication app) : base(app, typeof(TRequest))
    {        
        Delegate = async (context) =>
        {
            Logger.LogInformation("Handling mediator request: {RequestType}", Type.Name);

            var mediator = context.RequestServices.GetRequiredService<IMediator>();
            var request = await context.Request.ReadFromJsonAsync(typeof(TRequest), AppJsonSerializerContext.Default);
            if (request == null)
            {
                await context.Response.WriteAsync("Invalid request payload.");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            var response = await mediator.Send(request);
            if (response == null)
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return; 
            }

            await context.Response.WriteAsJsonAsync(response, response.GetType(), AppJsonSerializerContext.Default);
        };
    }
}

