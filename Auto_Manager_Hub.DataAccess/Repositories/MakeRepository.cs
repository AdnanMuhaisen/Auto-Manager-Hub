using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    internal class MakeRepository : Repository<TblMake>, IMakeRepository
    {
        public MakeRepository(AppDbContext context) : base(context) { }
        

        public void Update(TblMake entity)
        {
            _context.Update(entity);
        }
    }
}
