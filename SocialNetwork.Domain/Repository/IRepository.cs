namespace SocialNetwork.Domain.Repository;

public interface IRepository<T>
{
    public IEnumerable<T> GetAll();

    public T? GetById(int id);

    public T? Post(T entity);

    public bool Put(int id, T entity);

    public bool Delete(int id);
}
