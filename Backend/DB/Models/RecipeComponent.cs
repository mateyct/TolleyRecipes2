using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Backend.DB.Models;

public class RecipeComponent
{
    public required string Id { get; set; }
    public required bool PrimaryComponent { get; set; } = false;
    public string? Title { get; set; }
    [DataType(DataType.ImageUrl)]
    public string? ImageUrl { get; set; }
    public int? PrepTime { get; set; }
    public int? CookTime { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Recipe? Recipe { get; set; }
    public List<Ingredient> Ingredients { get; set; } = [];
    public List<RecipeInstruction> Instructions { get; set; } = [];
}
