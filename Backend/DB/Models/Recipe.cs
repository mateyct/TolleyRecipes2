using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Constants;
using Microsoft.EntityFrameworkCore;

namespace Backend.DB.Models;

public class Recipe
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    [DataType(DataType.ImageUrl)]
    public string? ImageUrl { get; set; }
    public required int PrepTime { get; set; }
    public required int CookTime { get; set; }
    public int? Calories { get; set; }
    public int? Servings { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public required string AuthorName { get; set; }
    public required float Rating { get; set; }
    public required Category RecipeCategory { get; set; }
    public required List<RecipeComponent> Components { get; set; } = [];
    [ForeignKey(nameof(User))]
    public required string UserId { get; set; }
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public User? User { get; set; }
}
