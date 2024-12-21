using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Domain.Repository;

public class UserRepository : IRepository<User>
{
    private readonly SocialNetworkContext? _dbContext;

    public UserRepository(SocialNetworkContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Delete(int id)
    {
        var user = _dbContext!.Users.Find(id);
        if (user == null)
        {
            return false;
        }

        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();
        return true;
    }

    public IEnumerable<User> GetAll()
    {
        return _dbContext!.Users.ToList();
    }

    public User? GetById(int id)
    {
        return _dbContext!.Users.Find(id);
    }

    public User? Post(User entity)
    {
        _dbContext!.Users.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public bool Put(int id, User entity)
    {
        var oldUser = _dbContext!.Users.Find(id);
        if (oldUser == null)
        {
            return false;
        }

        oldUser.FirstName = entity.FirstName;
        oldUser.LastName = entity.LastName;
        oldUser.Email = entity.Email;
        oldUser.CreatedAt = entity.CreatedAt;

        _dbContext.SaveChanges();
        return true;
    }
}
