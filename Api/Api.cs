using Self.Api.Apps;
using Self.Api.Auth;
using Self.Api.Middleware.Db;
using Self.Api.Middleware.Events;
using Self.Api.Middleware.Web;

var builder = WebApplication.CreateSlimBuilder(args);
var services = builder.Services;
var version = 1;

services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppsSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthSerializerContext.Default);
});

services.ConfigureAuthOptions(options =>
{
    options.JwtKey = builder.Configuration.GetValue<string>("Auth:Key");
});

services.ConfigureDbAccessOptions(options =>
{
    options.PrimaryDbConnection = builder.Configuration.GetConnectionString("PrimaryDbConnection");
    options.ReplicaDbConnection = builder.Configuration.GetConnectionString("ReplicaDbConnection");
});

services.ConfigureEventBusOptions(options =>
{
    // Configure event bus options here
});

services.ConfigureWebAccessOptions(options =>
{
    options.EnabledOpenApi = true;
    options.IsProduction = builder.Environment.IsProduction();
});

var app = builder.Build();

app.UseAuth();
app.UseWebAccess();

var root = app.MapGroup($"/v{version}");
app.MapAppsEndpoints(root, version);
app.MapAuthEndpoints(root, version);

app.Run();