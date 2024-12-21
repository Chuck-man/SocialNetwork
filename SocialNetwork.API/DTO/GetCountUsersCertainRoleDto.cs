namespace SocialNetwork.API.DTO;

public class GetCountUsersCertainRoleDto
{
    public string? groupName {  get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? roleName { get; set; }

    public int? Count { get; set; }
}
