using System.Linq.Expressions;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(bool AsNoTracking = false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> range);
        T? GetFirstOrDefault(bool AsNoTracking = false);
        T? Get(Expression<Func<T, bool>> filter, bool AsNoTracking = false);
    }
}
