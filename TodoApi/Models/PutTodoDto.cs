namespace TodoApi.Models;

// Data transfer object for PUT requests; it will be converted to a TodoItem before being sent to DB
public class PutTodoDto
{
    public string? Title { get; set; }
    public bool? Completed { get; set; }

    // Convert self to TodoItem before adding to DB
    public TodoItem ToTodoItem(TodoItem oldTodo)
    {
        // Ensure that none of the properties are null by setting to previous values
        Title ??= oldTodo.Title;
        Completed ??= oldTodo.Completed;
        return new TodoItem { Title = Title, Completed = Completed.Value };
    }
}