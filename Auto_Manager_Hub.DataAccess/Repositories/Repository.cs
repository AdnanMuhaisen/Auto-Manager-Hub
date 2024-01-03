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

        public IEnumerable<T> GetAll(bool AsNoTracking = false)
        {
            if(!AsNoTracking)
            {
                return dbSet.ToList();
            }

            return dbSet.AsNoTracking().ToList();
        }

        public T? GetFirstOrDefault(bool AsNoTracking = false)
        {
            if(!AsNoTracking)
            {
                return dbSet.FirstOrDefault();
            }
            return dbSet.AsNoTracking().FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Entry(entity).State = EntityState.Deleted;
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> range)
        {
            dbSet.RemoveRange(range);
        }

        public T? Get(Expression<Func<T, bool>> filter, bool AsNoTracking = false)
        {
            if (!AsNoTracking)
            {
                return dbSet.Where(filter).FirstOrDefault();
            }

            return dbSet.AsNoTracking().Where(filter).FirstOrDefault();
        }
    }
}
