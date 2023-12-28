using Auto_Manager_Hub.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public AppDbContext _context { get; set; } = null!;
        public DbSet<T> dbSet { get; set; } = null!;

        public Repository(AppDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public T? GetFirstOrDefault()
        {
            return dbSet.AsNoTracking().FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> range)
        {
            dbSet.RemoveRange(range);
        }

        public T? Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.AsNoTracking().Where(filter).FirstOrDefault();
        }
    }
}
