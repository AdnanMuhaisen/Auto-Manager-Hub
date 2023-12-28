using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IBodyRepository : IRepository<TblBody>
    {
        void Update(TblBody entity);
    }
}
