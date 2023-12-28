using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IMakeRepository : IRepository<TblMake>
    {
        void Update(TblMake entity);
    }
}
