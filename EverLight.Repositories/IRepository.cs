namespace EverLight.Repositories
{
    public interface IRepository<T> where T : class
    {
        int Create(T entity);
        IEnumerable<T> GetAll();
        void Update(T order);
    }
}