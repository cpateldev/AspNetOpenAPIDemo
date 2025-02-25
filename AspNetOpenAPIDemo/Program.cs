using CoreWebAPI;
using Microsoft.EntityFrameworkCore;
namespace AspNetOpenAPIDemo
{
    public class Program
    {
        internal static void PopulateTodoDB(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TodoDb>();
                db.Todos.Add(new Todo { Name = "Go to watch movie" });
                db.Todos.Add(new Todo { Name = "Get the dog for a walk", IsComplete = true });
                db.Todos.Add(new Todo { Name = "Buy 3 gallons of milk" });
                db.Todos.Add(new Todo { Name = "Call mom", IsComplete = true });
                db.Todos.Add(new Todo { Name = "Do the laundry" });
                db.Todos.Add(new Todo { Name = "Finish the book", IsComplete = true });
                db.Todos.Add(new Todo { Name = "Go to the gym" });
                db.Todos.Add(new Todo { Name = "Buy a new phone", IsComplete = true });
                db.Todos.Add(new Todo { Name = "Get the car fixed" });
                db.Todos.Add(new Todo { Name = "Go to the supermarket", IsComplete = true });
                db.SaveChanges();
            }
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            PopulateTodoDB(app.Services);

            app.MapGet("/todoitems", async (TodoDb db) =>
                await db.Todos.ToListAsync())
                .WithOpenApi();

            app.MapGet("/todoitems/complete", async (TodoDb db) =>
                await db.Todos.Where(t => t.IsComplete).ToListAsync());

            app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
                await db.Todos.FindAsync(id)
                    is Todo todo
                        ? Results.Ok(todo)
                        : Results.NotFound());

            app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
            {
                db.Todos.Add(todo);
                await db.SaveChangesAsync();

                return Results.Created($"/todoitems/{todo.Id}", todo);
            });

            app.MapPatch("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
            {
                var todo = await db.Todos.FindAsync(id);

                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                //todo.IsComplete = inputTodo.IsComplete;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
            {
                var todo = await db.Todos.FindAsync(id);

                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            // POST /todoitems/batch
            app.MapPost("/todoitems/batch", async (Todo[] todos, TodoDb db) =>
            {
                await db.Todos.AddRangeAsync(todos);
                await db.SaveChangesAsync();

                return Results.Ok(todos);
            });

            app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    db.Todos.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.Ok(todo);
                }

                return Results.NotFound();
            });

            app.Run();
        }
    }
}
