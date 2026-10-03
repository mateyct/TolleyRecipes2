using System;
using Microsoft.EntityFrameworkCore;

namespace Backend.DB.Models;

public class Ingredient
{
    public required string Id { get; set; }
    public int? Fraction { get; set; }
    public string? MeasurementUnit { get; set; }
    public int? Quantity { get; set; }
    public required string ItemName { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public RecipeComponent? RecipeComponent { get; set; }
}
