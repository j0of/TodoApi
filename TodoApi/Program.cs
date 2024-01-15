using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseSqlite("Data Source=db.sqlite")); // db.sqlite = location of DB file
builder.Services.AddScoped<TodoService>(); // Allows us to inject a TodoService into Controllers via dependency
                                           //  injection. A new instance of the service is created every request.

var app = builder.Build();

app.MapControllers(); // Maps controller routes
app.UseStaticFiles(); // Allows static files (i.e. images) to be loaded

app.Run();