using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Services;

// These methods will allow us to interact with the DB from a Controller
public class TodoService
{
    private readonly TodoContext _context;

    public TodoService(TodoContext context)
    {
        _context = context; // Store the TodoContext via dependency injection
    }

    // Returns all TodoItems in DB
    public async Task<List<TodoItem>> GetTodoItems()
    {
        return await _context.TodoItems.ToListAsync(); // Dunno why I did this TBH. ChatGPT says it's good :-)
    }

    // Returns one TodoItem from DB via its ID
    public async Task<TodoItem> GetTodoItem(int id)
    {
        var todo = await _context.TodoItems.FindAsync(id); // Check for TodoItem with the id
        if (todo == null)
        {
            throw new ArgumentException($"TodoItem with ID {id} not found"); // it doesn't exist; throw error
        }

        return todo;
    }

    // Adds a new TodoItem to the DB and returns it
    public async Task<TodoItem> AddTodoItem(TodoItem todo)
    {
        var newTodo = _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync(); // Save changes (added new TodoItem)
        return newTodo.Entity;
    }

    // Removes a TodoItem from the DB
    public async Task DeleteTodoItem(int id)
    {
        var todo = await _context.TodoItems.FindAsync(id); // Check for the TodoItem we're trying to delete
        if (todo == null)
        {
            throw new ArgumentException($"TodoItem with ID {id} not found"); // It doesn't exist; throw error
        }

        _context.TodoItems.Remove(todo);
        await _context.SaveChangesAsync(); // Save changes (removed TodoItem)
    }

    // Updates a TodoItem in the DB
    public async Task PutTodoItem(int id, TodoItem updatedTodo)
    {
        // Replace old todo item with new todo item
        var todo = await _context.TodoItems.FindAsync(id); // Find the original TodoItem that we're trying to change
        if (todo == null)
        {
            throw new ArgumentException($"TodoItem with ID {id} not found"); // Original TodoItem doesn't exist; throw error
        }
        
        // Update the old TodoItem's properties with the new ones
        todo.Title = updatedTodo.Title;
        todo.Completed = updatedTodo.Completed;

        await _context.SaveChangesAsync(); // Save changes (updated TodoItem)
    }
}