namespace SocialNetwork.Domain.Entities;

public class Member
{
    public int Id { get; set; }
    public required Group Group { get; set; }
    public int GroupId { get; set; }
    public required User User { get; set; }
    public int UserId { get; set; }
    public required DateTime JoinedAt { get; set; }
    public required Role Role { get; set; }
    public int RoleId { get; set; }
}
