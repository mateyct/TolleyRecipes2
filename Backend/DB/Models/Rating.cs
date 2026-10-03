using System;
using Microsoft.EntityFrameworkCore;

namespace Backend.DB.Models;

public class Rating
{
    public required string Id { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public required User User { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public required Recipe Recipe { get; set; }
    public required int Score { get; set; }
    public required string Title { get; set; }
    public required string Review { get; set; }
}
