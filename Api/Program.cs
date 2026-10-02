using Api.Application;
using Api.Auth;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, ApplicationSerializerContext.Default);
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthSerializerContext.Default);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var root = app.MapGroup("/api/v1");
app.MapApplicationEndpoints(root);
app.MapAuthEndpoints(root);

app.Run();