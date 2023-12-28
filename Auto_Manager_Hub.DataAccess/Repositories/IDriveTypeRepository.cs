using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IDriveTypeRepository : IRepository<TblDriveType>
    {
        void Update(TblDriveType driveType);

    }
}
