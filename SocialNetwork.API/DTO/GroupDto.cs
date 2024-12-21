using System.Text.Json;

namespace SocialNetwork.API.DTO;

public class GroupDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required int OwnerId { get; set; }
    public string? GroupInfo { get; set; }
}
