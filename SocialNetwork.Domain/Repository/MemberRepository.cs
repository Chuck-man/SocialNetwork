using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Domain.Repository;

public class MemberRepository : IRepository<Member>
{
    private readonly SocialNetworkContext? _dbContext;

    public MemberRepository(SocialNetworkContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Delete(int id)
    {
        var member = _dbContext!.Members.Find(id);
        if (member == null)
        {
            return false;
        }

        _dbContext.Members.Remove(member);
        _dbContext.SaveChanges();
        return true;
    }

    public IEnumerable<Member> GetAll()
    {
        return _dbContext!.Members.Include(gm => gm.Group).Include(gm => gm.Role).Include(gm => gm.User).ToList();
    }

    public Member? GetById(int id)
    {
        return _dbContext!.Members.Include(gm => gm.Group).Include(gm => gm.Role).Include(gm => gm.User).FirstOrDefault(m => m.Id == id);
    }

    public Member? Post(Member entity)
    {
        _dbContext!.Members.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public bool Put(int id, Member entity)
    {
        var oldMember = _dbContext!.Members.Find(id);
        if (oldMember == null)
        {
            return false;
        }

        oldMember.Group = entity.Group;
        oldMember.User = entity.User;
        oldMember.JoinedAt = entity.JoinedAt;
        oldMember.Role = entity.Role;

        _dbContext.SaveChanges();
        return true;
    }
}
