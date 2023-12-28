using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public class SubModelRepository : Repository<TblSubModel>, ISubModelRepository
    {
        public SubModelRepository(AppDbContext context):base(context) { }   

        public void Update(TblSubModel entity)
        {
            _context.Update(entity);
        }
    }
}
