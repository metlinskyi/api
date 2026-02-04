namespace Api.Middleware.Routing;

public abstract class Endpoint(WebApplication application, Type type)  
{
    protected RequestDelegate Delegate { get; set; } = async (context) => { throw new NotImplementedException(); };
    protected Type Type { get; private set; } = type;
    protected WebApplication Application { get; private set; } = application;
    protected ILogger Logger { get; } = application.Logger;
    protected EndpointMapper Mapper { get; } = application.Services.GetRequiredService<EndpointMapper>();
    protected string Pattern  { get; set; } = string.Empty;
    
    public IEndpointConventionBuilder AsGet()
    {
        Logger.LogInformation("GET: {Pattern}", Pattern);
        return Application.MapGet(Pattern, Delegate);
    }

    public IEndpointConventionBuilder AsPost()
    {
        Logger.LogInformation("POST: {Pattern}", Pattern);
        return Application.MapPost(Pattern, Delegate);
    }

    public IEndpointConventionBuilder AsPut()
    {
        Logger.LogInformation("PUT: {Pattern}", Pattern);      
        return Application.MapPut(Pattern, Delegate);
    }

    public IEndpointConventionBuilder AsDelete()
    {
        Logger.LogInformation("DELETE: {Pattern}", Pattern);
        return Application.MapDelete(Pattern, Delegate);
    }
}
