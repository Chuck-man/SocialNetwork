using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.DTO;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Repository;

namespace SocialNetwork.API.Controllers;

public class QueryController(IRepository<Group> groupRepository, IRepository<Member> memberRepository, IRepository<Post> postRepository, IRepository<Comment> commentRepository, IMapper mapper) : Controller
{
    [HttpGet("UsersInGroup")]
    public ActionResult<IEnumerable<MemberFullDto>> GetUsersInGroup(string groupName)
    {
        var group = groupRepository.GetAll().FirstOrDefault(g => g.Name == groupName);

        if (group == null)
        {
            return NotFound($"Группа с именем '{groupName}' не найдена.");
        }

        var usersInGroup = memberRepository.GetAll()
            .Where(gm => gm.GroupId == group.Id)
              .ToList();

        var result = usersInGroup.Select(x => mapper.Map<MemberFullDto>(x));

        return Ok(result);
    }

    [HttpGet("GroupPostCounts")]
    public ActionResult<IEnumerable<GetCountPostsDto>> GetGroupPostCounts()
    {
        var groupCounts = groupRepository.GetAll()
             .Select(group => new GetCountPostsDto
             {
                 GroupName = group.Name,
                 Description = group.Description,
                 Count = postRepository.GetAll().Count(post => post.GroupId == group.Id)
             })
             .OrderByDescending(x => x.Count)
              .ToList();

        return Ok(groupCounts);
    }

    [HttpGet("GroupUsersByRole")]
    public ActionResult<IEnumerable<GetCountUsersCertainRoleDto>> GetGroupUsersByRole(int year)
    {
        var result = groupRepository.GetAll()
            .Where(g => g.CreatedAt.Year == year)
            .SelectMany(group => memberRepository.GetAll()
                .Where(member => member.GroupId == group.Id)
                .GroupBy(member => member.Role)
                .Select(grouping => new GetCountUsersCertainRoleDto
                {
                    groupName = group.Name,
                    CreatedAt = group.CreatedAt,
                    roleName = grouping.Key.Name,
                    Count = grouping.Count()
                }))
            .OrderBy(dto => dto.groupName)
             .ThenBy(dto => dto.roleName)
             .ToList();
        return Ok(result);
    }

    [HttpGet("PostsWithManyComments")]
    public ActionResult<IEnumerable<GetPostsByCommentsCountDto>> GetPostsWithManyComments()
    {
        var result = postRepository.GetAll()
           .Select(post => new GetPostsByCommentsCountDto
           {
               GroupName = post.Group.Name,
               PostText = post.Content,
               FirstName = post.User.FirstName,
               LastName = post.User.LastName,
               Count = commentRepository.GetAll().Count(comment => comment.PostId == post.Id)
           })
           .Where(x => x.Count > 2)
           .OrderByDescending(x => x.Count)
            .ToList();
        return Ok(result);
    }

    [HttpGet("GroupsWithMaxMembers")]
    public ActionResult<IEnumerable<GetGroupsByMaxUsersDto>> GetGroupsWithMaxMembers()
    {
        var maxMemberCount = memberRepository.GetAll().GroupBy(m => m.GroupId).Max(g => g.Count());

        var groupsWithMaxMembers = groupRepository.GetAll()
            .Where(g => memberRepository.GetAll().Count(m => m.GroupId == g.Id) == maxMemberCount)
            .Select(g => new GetGroupsByMaxUsersDto
            {
                GroupName = g.Name,
                OwnerFirstName = g.Owner.FirstName,
                OwnerLastName = g.Owner.LastName
            })
            .OrderBy(g => g.GroupName) //Order by group name
            .ToList();
        return Ok(groupsWithMaxMembers);
    }

    [HttpGet("PostStatistics")]
    public ActionResult<GetPostsInfoDto> GetPostStatistics()
    {
        var postCounts = groupRepository.GetAll()
            .Select(g => postRepository.GetAll().Count(p => p.GroupId == g.Id))
            .ToList();

        var result = new GetPostsInfoDto
        {
            min = postCounts.Any() ? postCounts.Min() : 0,
            avg = postCounts.Any() ? (int)postCounts.Average() : 0,
            max = postCounts.Any() ? postCounts.Max() : 0
        };

        return Ok(result);
    }
}
