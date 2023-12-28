using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public class FuelTypeRepository : Repository<TblFuelType>, IFuelTypeRepository
    {
        public FuelTypeRepository(AppDbContext context):base(context) { }

        public void Update(TblFuelType entity)
        {
            _context.Update(entity);
        }
    }
}
