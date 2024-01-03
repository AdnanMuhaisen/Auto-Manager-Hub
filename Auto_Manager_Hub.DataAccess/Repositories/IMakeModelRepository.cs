using Auto_Manager_Hub.DataAccess.Functions.TVF;
using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IMakeModelRepository : IRepository<MakeModel>
    {
        void Update(MakeModel entity);
    }
}
