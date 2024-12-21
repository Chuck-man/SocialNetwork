using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Domain.Repository;

public class RoleRepository : IRepository<Role>
{
    private readonly SocialNetworkContext? _dbContext;

    public RoleRepository(SocialNetworkContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Delete(int id)
    {
        var role = _dbContext!.Roles.Find(id);
        if (role == null)
        {
            return false;
        }

        _dbContext.Roles.Remove(role);
        _dbContext.SaveChanges();
        return true;
    }

    public IEnumerable<Role> GetAll()
    {
        return _dbContext!.Roles.ToList();
    }

    public Role? GetById(int id)
    {
        return _dbContext!.Roles.Find(id);
    }

    public Role? Post(Role entity)
    {
        _dbContext!.Roles.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public bool Put(int id, Role entity)
    {
        var oldRole = _dbContext!.Roles.Find(id);
        if (oldRole == null)
        {
            return false;
        }

        oldRole.Name = entity.Name;

        _dbContext.SaveChanges();
        return true;

    }
}
