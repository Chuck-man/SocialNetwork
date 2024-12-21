using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Domain.Repository;

public class PostRepository : IRepository<Post>
{
    private readonly SocialNetworkContext? _dbContext;

    public PostRepository(SocialNetworkContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Delete(int id)
    {
        var post = _dbContext!.Posts.Find(id);
        if (post == null)
        {
            return false;
        }
        _dbContext.Posts.Remove(post);
        _dbContext.SaveChanges();
        return true;
    }

    public IEnumerable<Post> GetAll()
    {
        return _dbContext!.Posts.Include(p => p.User).Include(p => p.Group).ToList();
    }

    public Post? GetById(int id)
    {
        return _dbContext!.Posts.Include(p => p.User).Include(p => p.Group).FirstOrDefault(p => p.Id == id);
    }

    public Post? Post(Post entity)
    {
        _dbContext!.Posts.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public bool Put(int id, Post entity)
    {
        var oldPost = _dbContext!.Posts.Find(id);
        if (oldPost == null)
        {
            return false;
        }

        oldPost.Group = entity.Group;
        oldPost.User = entity.User;
        oldPost.Content = entity.Content;
        oldPost.CreatedAt = entity.CreatedAt;
        oldPost.Lat = entity.Lat;
        oldPost.Lon = entity.Lon;

        _dbContext.SaveChanges();
        return true;
    }
}
