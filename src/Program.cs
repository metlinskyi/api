var builder = WebApplication.CreateSlimBuilder(args);
var app = builder.Build();

var api = app.MapGroup("/api");
api.MapGet("/", () => "Hello, World!");
app.Run();
