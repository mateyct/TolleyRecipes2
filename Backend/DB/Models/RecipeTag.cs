using System;
using Microsoft.EntityFrameworkCore;

namespace Backend.DB.Models;

public class RecipeTag
{
    public required string Id { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public required Recipe Recipe { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public required Tag Tag { get; set; }
}
