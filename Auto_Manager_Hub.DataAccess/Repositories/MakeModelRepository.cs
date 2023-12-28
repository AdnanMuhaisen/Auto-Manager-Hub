using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.DataAccess.Functions.TVF;
using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public class MakeModelRepository : Repository<TblMakeModel>, IMakeModelRepository
    {
        public MakeModelRepository(AppDbContext context) : base(context) { }
        
        public void Update(TblMakeModel entity)
        {
            _context.Update(entity);
        }
    }
}
