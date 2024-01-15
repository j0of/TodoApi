namespace TodoApi.Models;

// Model for TodoItems; data taken from the DB will have this format
public class TodoItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool Completed { get; set; }
}