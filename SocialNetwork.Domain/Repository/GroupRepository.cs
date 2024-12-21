using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Domain.Repository;

public class GroupRepository : IRepository<Group>
{
    private readonly SocialNetworkContext? _dbContext;

    public GroupRepository(SocialNetworkContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Delete(int id)
    {
        var group = _dbContext!.Groups.Find(id);
        if (group == null)
        {
            return false;
        }
        _dbContext.Groups.Remove(group);
        _dbContext.SaveChanges();
        return true;
    }

    public IEnumerable<Group> GetAll()
    {
        return _dbContext!.Groups.Include(g => g.Owner).ToList();
    }

    public Group? GetById(int id)
    {
        return _dbContext!.Groups.Include(g => g.Owner).FirstOrDefault(g => g.Id == id);
    }

    public Group? Post(Group entity)
    {
        _dbContext!.Groups.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public bool Put(int id, Group entity)
    {
        var oldGroup = _dbContext!.Groups.Find(id);
        if (oldGroup == null)
        {
            return false;
        }

        oldGroup.Name = entity.Name;
        oldGroup.Description = entity.Description;
        oldGroup.CreatedAt = entity.CreatedAt;
        oldGroup.Owner = entity.Owner;
        oldGroup.GroupInfo = entity.GroupInfo;

        _dbContext.SaveChanges();
        return true;
    }
}
