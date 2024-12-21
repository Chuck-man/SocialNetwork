namespace SocialNetwork.API.DTO;

public class PostFullDto
{
    public int Id { get; set; }
    public required GroupDto Group { get; set; }
    public required UserDto User { get; set; }
    public required string Content { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required double Lat { get; set; }
    public required double Lon { get; set; }
}
