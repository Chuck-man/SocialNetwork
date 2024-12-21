namespace SocialNetwork.API.DTO;

public class CommentFullDto
{
    public int Id { get; set; }
    public required PostDto Post { get; set; }
    public required UserDto User { get; set; }
    public required string Content { get; set; }
    public required DateTime CreatedAt { get; set; }
}
