using Self.Api.Apps;
using Self.Api.Auth;


var builder = WebApplication.CreateSlimBuilder(args);
var services = builder.Services;

services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppsSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthSerializerContext.Default);
});

services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();


var root = app.MapGroup("/api/v1");
app.MapAppsEndpoints(root);
app.MapAuthEndpoints(root);

app.Run();