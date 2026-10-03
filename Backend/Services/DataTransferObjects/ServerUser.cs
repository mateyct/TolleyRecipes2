using System;
using Backend.Constants;
using System.ComponentModel.DataAnnotations;

namespace Backend.Services.DataTransferObjects;

public class ServerUser
{
    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role? UserRole { get; set; }
    [DataType(DataType.ImageUrl)]
    public string? ProfilePictureUrl { get; set; }
}
