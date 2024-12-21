using System.Text.Json;

namespace SocialNetwork.Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required User Owner { get; set; }
    public int OwnerId { get; set; }
    public string? GroupInfo { get; set; }
}
