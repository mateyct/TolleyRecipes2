using System;
using Microsoft.EntityFrameworkCore;

namespace Backend.DB.Models;

public class RecipeInstruction
{
    public required string Id { get; set; }
    public required int Ordinal { get; set; }
    public required string Instruction { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public RecipeComponent? RecipeComponent { get; set; }
}
