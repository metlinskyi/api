using Api.Routes;
using Api.Services;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);
var config = builder.Configuration;

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});
// Add database context
builder.Services.AddDb(_ => {
    _.UseNpgsql(config.GetConnectionString("DefaultConnection")!);
}); 

// Add MediatR
builder.Services.AddMediatR(_ => {
    _.RegisterServicesFromAssemblyContaining<Program>();
});

// Map AutoMapper profiles
builder.Services.AddAutoMapper(_ => {
    _.AddMaps(typeof(Program).Assembly);
});

// Add gRPC services
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapEndpoints();
app.MapServices();
app.Run();