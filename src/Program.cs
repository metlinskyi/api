using Api.Routes;
using Api.Services;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);
var config = builder.Configuration;

// Add database context
builder.Services.AddDb(builder=> {
    builder.UseNpgsql(config.GetConnectionString("DefaultConnection")!);
}); 

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapEndpoints();
app.MapServices();
app.Run();