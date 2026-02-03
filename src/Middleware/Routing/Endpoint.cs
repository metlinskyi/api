namespace Api.Middleware.Routing;

public abstract class Endpoint(WebApplication application, Type type)  
{
    protected RequestDelegate Delegate { get; set; } = async (context) => { throw new NotImplementedException(); };
    protected Type Type { get; private set; } = type;
    protected WebApplication Application { get; private set; } = application;
    protected ILogger Logger { get; } = application.Logger;

    protected EndpointMapper Mapper { get; } = application.Services.GetRequiredService<EndpointMapper>();
    
    public IEndpointConventionBuilder AsGet()
    {
        return Application.MapGet(Mapper.BuildPattern(Type), Delegate);
    }

    public IEndpointConventionBuilder AsPost()
    {
        return Application.MapPost(Mapper.BuildPattern(Type), Delegate);
    }

    public IEndpointConventionBuilder AsPut()
    {
        return Application.MapPut(Mapper.BuildPattern(Type), Delegate);
    }

    public IEndpointConventionBuilder AsDelete()
    {
        return Application.MapDelete(Mapper.BuildPattern(Type), Delegate);
    }
}
