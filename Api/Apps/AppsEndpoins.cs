using Microsoft.AspNetCore.Http.HttpResults;

namespace Self.Api.Apps;
/// <summary>
/// Endpoints for applications
/// </summary>
internal static class AppsEndpoints
{
    public static void MapAppsEndpoints(this WebApplication webApp, RouteGroupBuilder root, int version)
    {
        var apps = root.MapGroup("/apps");
    
        Todo[] sampleTodos =
        [
            new(1, "Walk the dog"),
            new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
            new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
            new(4, "Clean the bathroom"),
            new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
        ];

        apps.MapGet("/", () => sampleTodos)
            .WithName("GetTodos");

        apps.MapGet("/{id}", Results<Ok<Todo>, NotFound> (int id) =>
            sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
                ? TypedResults.Ok(todo)
                : TypedResults.NotFound())
            .WithName("GetTodoById");
    }
}