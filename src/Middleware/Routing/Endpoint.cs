namespace Api.Middleware.Routing;

public abstract class Endpoint(WebApplication application, Type type)  
{
    protected RequestDelegate Delegate { get; set; } = async (context) => { throw new NotImplementedException(); };
    protected Type Type { get; private set; } = type;
    protected WebApplication Application { get; private set; } = application;
    protected ILogger Logger { get; } = application.Logger;
    
    public IEndpointConventionBuilder AsGet()
    {
        return Application.MapGet(BuildPattern(Type), Delegate);
    }

    public IEndpointConventionBuilder AsPost()
    {
        return Application.MapPost(BuildPattern(Type), Delegate);
    }

    public IEndpointConventionBuilder AsPut()
    {
        return Application.MapPut(BuildPattern(Type), Delegate);
    }

    public IEndpointConventionBuilder AsDelete()
    {
        return Application.MapDelete(BuildPattern(Type), Delegate);
    }

    protected string BuildPattern(Type type)
    {
        var pattern = $"{type.Namespace?.Replace(".", "/")}/{type.Name.Replace("Request", "")}".ToLower();
        Logger.LogInformation("Mapping mediator endpoint: {Pattern}", pattern);
        return pattern;
    }
}
