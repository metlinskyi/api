using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Application;

internal static class ApplicationEndpoints
{
    public static void MapApplicationEndpoints(this WebApplication app, RouteGroupBuilder root)
    {
        Todo[] sampleTodos =
        [
            new(1, "Walk the dog"),
            new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
            new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
            new(4, "Clean the bathroom"),
            new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
        ];

        root.MapGet("/", () => sampleTodos)
                .WithName("GetTodos");

        root.MapGet("/{id}", Results<Ok<Todo>, NotFound> (int id) =>
            sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
                ? TypedResults.Ok(todo)
                : TypedResults.NotFound())
            .WithName("GetTodoById");
    }
}