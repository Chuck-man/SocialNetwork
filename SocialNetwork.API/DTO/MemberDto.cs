namespace SocialNetwork.API.DTO;

public class MemberDto
{
    public required int GroupId { get; set; }
    public required int UserId { get; set; }
    public required DateTime JoinedAt { get; set; }
    public required int RoleId { get; set; }
}
