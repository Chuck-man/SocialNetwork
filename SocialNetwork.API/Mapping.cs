using AutoMapper;
using SocialNetwork.API.DTO;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.API;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<User, UserFullDto>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();

        CreateMap<Group, GroupFullDto>().ReverseMap();
        CreateMap<GroupDto, Group>().ReverseMap();

        CreateMap<Member, MemberFullDto>().ReverseMap();
        CreateMap<MemberDto, Member>().ReverseMap();

        CreateMap<Role, RoleFullDto>().ReverseMap();
        CreateMap<RoleDto, Role>().ReverseMap();

        CreateMap<Post, PostFullDto>().ReverseMap();
        CreateMap<PostDto, Post>().ReverseMap();

        CreateMap<Comment, CommentFullDto>().ReverseMap();
        CreateMap<CommentDto, Comment>().ReverseMap();
    }
}
