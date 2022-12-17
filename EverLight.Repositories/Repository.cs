using EverLight.DC;
using EverLight.DTOs;

namespace EverLight.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext dataContext;

        public Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public T Create(T entity)
        {
            var ent = dataContext.Add(entity);
            dataContext.SaveChanges();

            return ent.Entity;
        }

        public IEnumerable<T> GetAll()
        {
            return dataContext.Set<T>();
        }

        public void Update(T order)
        {
            dataContext.Update(order);
            dataContext.SaveChanges();
        }
    }
}