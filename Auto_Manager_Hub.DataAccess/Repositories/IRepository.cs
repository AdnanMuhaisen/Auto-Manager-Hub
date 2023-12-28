using System.Linq.Expressions;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> range);
        T? GetFirstOrDefault();
        T? Get(Expression<Func<T, bool>> filter);
    }
}
