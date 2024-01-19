using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
public class TodoController : Controller
{
    private TodoService _todoService;
    public TodoController(TodoService todoService) // Inject & store a todoService, allowing us to interact with DB
    {                                              // with abstractions
        _todoService = todoService;
    }

    // GET: api/todo/
    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var todos = await _todoService.GetTodoItems();
        return Ok(todos);
    }

    // GET: api/todo/1 
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodo(int id)
    {
        try
        {
            var todo = await _todoService.GetTodoItem(id); // Throws error if TodoItem doesn't exist
            return Ok(todo);
        }
        catch (ArgumentException e) // Handle the error if it happens
        {
            return NotFound(e.Message); // Give 404 response
        }
    }

    // POST: api/todo
    [HttpPost]
    public async Task<IActionResult> AddTodo([FromBody]PostTodoDto todo)
    {
        var newTodo = await _todoService.AddTodoItem(todo.ToTodoItem());
        return Created("Successfully created new TodoItem", newTodo);
    }

    // DELETE: api/todo/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        try
        {
            await _todoService.DeleteTodoItem(id); // Throws error if TodoItem doesn't exist
            return NoContent();
        }
        catch (ArgumentException e) // Handle error
        {
            return NotFound(e.Message); // Give 404 response
        }
    }

    // PUT: api/todo/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodo(int id, [FromBody]PutTodoDto todo) // [FromBody] tells it to look inside the
    {                                                                         // request body for the TodoItem
        try
        {
            // GetTodoItem() and PutTodoItem() both throw errors if the old Todo doesn't exist
            var oldTodo = await _todoService.GetTodoItem(id);
            await _todoService.PutTodoItem(id, todo.ToTodoItem(oldTodo));
            return NoContent();
        }
        catch (ArgumentException e) // Handle error
        {
            return NotFound(e.Message); // Give 404 response
        }
    }
}