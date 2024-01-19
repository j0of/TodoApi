namespace TodoApi.Models;

// Data transfer object for POST requests; it will be converted to a TodoItem before being sent to DB
public class PostTodoDto
{
    public string? Title { get; set; }
    public bool? Completed { get; set; }

    // Convert self to TodoItem before adding to DB
    public TodoItem ToTodoItem()
    {
        // Ensure that none of the properties are null by setting default values
        Title ??= "No title";
        Completed ??= false;
        return new TodoItem { Title = Title, Completed = Completed.Value };
    }
}