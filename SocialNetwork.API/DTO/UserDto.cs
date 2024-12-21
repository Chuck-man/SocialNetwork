﻿namespace SocialNetwork.API.DTO;

public class UserDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required DateTime CreatedAt { get; set; }
}