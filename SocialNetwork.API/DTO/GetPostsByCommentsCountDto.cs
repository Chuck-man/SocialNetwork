namespace SocialNetwork.API.DTO;

public class GetPostsByCommentsCountDto
{
    public string? GroupName { get; set; }
    public string? PostText { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Count { get; set; }
}
