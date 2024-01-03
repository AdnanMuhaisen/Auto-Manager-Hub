using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IBodyRepository : IRepository<Body>
    {
        void Update(Body entity);
    }
}
