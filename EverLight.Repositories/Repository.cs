using EverLight.DC;
using EverLight.DTOs;

namespace EverLight.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly DataContext dataContext;

        public Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public int Create(T entity)
        {
            var ent = dataContext.Add(entity);
            dataContext.SaveChanges();

            return ent.IsKeySet ? 1 : 0;
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