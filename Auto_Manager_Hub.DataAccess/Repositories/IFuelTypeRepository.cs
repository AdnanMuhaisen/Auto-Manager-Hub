using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IFuelTypeRepository : IRepository<TblFuelType>
    {
        void Update(TblFuelType entity);
    }
}
