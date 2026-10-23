using Self.Api.Apps;
using Self.Api.Auth;
using Self.Api.Events;
using Self.Api.Middleware.Caching;
using Self.Api.Middleware.Caching.Radis;
using Self.Api.Middleware.Db;
using Self.Api.Middleware.Db.PostgreSQL;
using Self.Api.Middleware.Events;
using Self.Api.Middleware.Events.RabbitMQ;
using Self.Api.Middleware.Web;

var builder = WebApplication.CreateSlimBuilder(args);
var settings = builder.Configuration;
var services = builder.Services;
var version = 1;

services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppsSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, EventBusSerializerContext.Default);
});

// Authorization 
services.ConfigureAuthOptions(options =>
{
    options.JwtKey = settings.GetValue<string>("Auth:Key");
});

// Cahing
services.ConfigureCachingOptions<RedisSettings>(options =>
{
    options.Settings = settings.GetValue<RedisSettings>("Caching:Redis")!;
});
  
// Database 
services.ConfigureDbAccessOptions<PostgreSQLBuilder>(options =>
{
    options.PrimaryDbConnection = settings.GetValue<string>("Db:PostgreSQL:PrimaryConnection")!;
    options.ReplicaDbConnection = settings.GetValue<string>("Db:PostgreSQL:ReplicaConnection")!;
});

// Event bus
services.ConfigureEventBusOptions<RabbitMQSettings>(options =>
{
    options.Settings = settings.GetValue<RabbitMQSettings>("Events:RabbitMQ")!;
});

// Web
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
app.MapEventBusEndpoints(root, version);

app.Run();