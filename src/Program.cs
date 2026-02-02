using Api.Services;
using Data;
using Microsoft.EntityFrameworkCore;

// Create the native AOT application builder
var builder = WebApplication.CreateSlimBuilder(args);
var config = builder.Configuration;


#region Builder Configuration

// Configure JSON options
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

// Add database context
builder.Services.AddDb(_ => 
{
    _.UseNpgsql(config.GetConnectionString("DefaultConnection")!);
}); 

// Add MediatR
builder.Services.AddMediatR(_ => 
{
    _.RegisterServicesFromAssemblyContaining<Program>();
});

// Map AutoMapper profiles
builder.Services.AddAutoMapper(_ => 
{
    _.AddMaps(typeof(Program).Assembly);    
});

// Configure endpoint mapping
builder.Services.AddEndpointMapping(_ => 
{
    _.UrlPattern = "/api/{namespace}/{classname}/";
    _.AddNamespacePattern("Api.Services.(?<namespace>.*)");
    _.AddClassnamePattern("(?<classname>.*)Service");
    _.AddClassnamePattern("(?<classname>.*)Handler");
});

// Add authentication and authorization
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

// Add gRPC services
builder.Services.AddGrpc();
if (builder.Environment.IsDevelopment())
    builder.Services.AddGrpcReflection();

#endregion


// Build the application
var app = builder.Build();

#region App Configuration

// Configure the HTTP request pipeline.
app.MapServices();
if (app.Environment.IsDevelopment())
    app.MapGrpcReflectionService();

#endregion


/// Start the application
app.Run();