namespace SocialNetwork.API.DTO;

public class CommentDto
{
    public required int PostId { get; set; }
    public required int UserId { get; set; }
    public required string Content { get; set; }
    public required DateTime CreatedAt { get; set; }
}
