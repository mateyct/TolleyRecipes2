using System.ComponentModel.DataAnnotations;
using Backend.Constants;

namespace Backend.DB.Models;

public class User
{
    public required string Id { get; set; }
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Role UserRole { get; set; }
    [DataType(DataType.ImageUrl)]
    public string? ProfilePictureUrl { get; set; }
    public required List<Recipe> Recipes { get; set; } = [];
}
