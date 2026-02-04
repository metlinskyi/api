using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Api.Middleware.Routing;

public class ServiceEndpoint<TService> : Endpoint
    where TService : notnull
{
    public ServiceEndpoint(WebApplication app, Expression<Func<TService, Delegate>> expression) : base(app, typeof(TService))
    {
        var name = expression.Compile().Invoke(default!).Method.Name;
        var info = typeof(TService).GetMethod(name); 
        if (info == null)
        {
            throw new InvalidOperationException($"Method '{name}' not found on service type '{typeof(TService).FullName}'.");
        }
        var returnType = info.ReturnType;
        var requestInfo = info.GetParameters();
        var parameters= info.GetParameters();

        var isTask = returnType.IsSubclassOf(typeof(Task));

        Pattern = Mapper.BuildPattern(typeof(TService)).Replace("{method}", name.ToLower());

        Delegate = async (context) =>
        {   
            Logger.LogInformation("Handling service request: {RequestType}", Type.Name);

            var service = context.RequestServices.GetRequiredService<TService>();

            var args = context.Request.Query
                    .Where(x=> parameters.Select(p=>p.Name).Contains(x.Key))
                    .Select(x=> Convert.ChangeType(x.Value.ToString(), parameters.First(p=>p.Name == x.Key).ParameterType))
                    .ToArray();


/*             var request = await context.Request.ReadFromJsonAsync(requestInfo.ParameterType, AppJsonSerializerContext.Default);
            if (request == null)
            {
                await context.Response.WriteAsync("Invalid request payload.");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            } */

            var method = expression.Compile().Invoke(service);


            object? response = null;    
            if (isTask && returnType.IsConstructedGenericType)
            {
                response = await (dynamic) method.DynamicInvoke(args);
            }
            else if (isTask)
            {
                await (Task) method.DynamicInvoke(args);
            }
            else
            {
                response = method.DynamicInvoke(args);
            }
            
            if (response == null)
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                return;
            }

            await context.Response.WriteAsJsonAsync(response, response.GetType(), AppJsonSerializerContext.Default);
        };
    }
}