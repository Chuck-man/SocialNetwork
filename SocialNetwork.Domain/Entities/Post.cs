namespace SocialNetwork.Domain.Entities;

public class Post
{
    public int Id { get; set; }
    public required Group Group { get; set; }
    public int GroupId { get; set; }
    public required User User { get; set; }
    public int UserId { get; set; }
    public required string Content { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required double Lat { get; set; }
    public required double Lon { get; set; }
}
