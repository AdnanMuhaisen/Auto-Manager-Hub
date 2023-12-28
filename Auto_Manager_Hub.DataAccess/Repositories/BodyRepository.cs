using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public class BodyRepository : Repository<TblBody>, IBodyRepository
    {
        public BodyRepository(AppDbContext context):base(context)
        {    

        }

        public void Update(TblBody entity)
        {
            _context.Update(entity);
        }
    }
}
