namespace SocialNetwork.API.DTO;

public class PostDto
{
    public required int GroupId { get; set; }
    public required int UserId { get; set; }
    public required string Content { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required double Lat { get; set; }
    public required double Lon { get; set; }
}
