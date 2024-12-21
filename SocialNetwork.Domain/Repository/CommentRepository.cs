using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Domain.Repository;

public class CommentRepository : IRepository<Comment>
{
    private readonly SocialNetworkContext? _dbContext;

    public CommentRepository(SocialNetworkContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Delete(int id)
    {
        var comment = _dbContext!.Comments.Find(id);
        if (comment == null)
        {
            return false;
        }

        _dbContext.Comments.Remove(comment);
        _dbContext.SaveChanges();
        return true;
    }

    public IEnumerable<Comment> GetAll()
    {
        return _dbContext!.Comments.Include(c => c.User).Include(c => c.Post).ToList();
    }

    public Comment? GetById(int id)
    {
        return _dbContext!.Comments.Include(c => c.User).Include(c => c.Post).FirstOrDefault(c => c.Id == id);
    }

    public Comment? Post(Comment entity)
    {
        _dbContext!.Comments.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public bool Put(int id, Comment entity)
    {
        var oldComment = _dbContext!.Comments.Find(id);
        if (oldComment == null)
        {
            return false;
        }

        oldComment.Post = entity.Post;
        oldComment.User = entity.User;
        oldComment.Content = entity.Content;
        oldComment.CreatedAt = entity.CreatedAt;

        _dbContext.SaveChanges();
        return true;
    }
}
