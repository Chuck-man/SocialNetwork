namespace SocialNetwork.API.DTO;

public class MemberFullDto
{
    public int Id { get; set; }
    public required GroupDto Group { get; set; }
    public required UserDto User { get; set; }
    public required DateTime JoinedAt { get; set; }
    public required RoleDto Role { get; set; }
}
