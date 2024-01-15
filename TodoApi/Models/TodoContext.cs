using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

// Database context for TodoItem - allows us to interact with database
public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }
}