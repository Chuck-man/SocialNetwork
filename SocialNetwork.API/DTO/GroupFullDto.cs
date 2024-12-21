using System.Text.Json;

namespace SocialNetwork.API.DTO;

public class GroupFullDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required UserDto Owner { get; set; }
    public string? GroupInfo { get; set; }
}
