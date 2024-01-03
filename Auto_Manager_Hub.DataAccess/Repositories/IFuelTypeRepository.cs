using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IFuelTypeRepository : IRepository<FuelType>
    {
        void Update(FuelType entity);
    }
}
