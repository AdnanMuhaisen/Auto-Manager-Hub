using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.DataAccess.Functions.TVF;
using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public class MakeModelRepository : Repository<MakeModel>, IMakeModelRepository
    {
        public MakeModelRepository(AppDbContext context) : base(context) { }
        
        public void Update(MakeModel entity)
        {
            _context.Update(entity);
        }
    }
}
