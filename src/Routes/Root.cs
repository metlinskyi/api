public class Root : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)   
    {
        await Send.OkAsync("Hello, World!");
    }
}