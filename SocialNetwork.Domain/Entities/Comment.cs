namespace SocialNetwork.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public required Post Post { get; set; }
    public int PostId { get; set; }
    public required User User { get; set; }
    public int UserId { get; set; }
    public required string Content { get; set; }
    public required DateTime CreatedAt { get; set; }
}
