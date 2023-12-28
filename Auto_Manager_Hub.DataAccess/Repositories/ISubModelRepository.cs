using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface ISubModelRepository:IRepository<TblSubModel>
    {
        void Update(TblSubModel entity);
    }
}
