using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

// Model for TodoItems; data taken from the DB will have this format
public class TodoItem
{
    public int Id { get; init; }
    [MaxLength(120)]
    public string Title { get; set; } = "";
    public bool Completed { get; set; }
}