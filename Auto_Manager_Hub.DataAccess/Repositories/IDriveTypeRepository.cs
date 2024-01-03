using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IDriveTypeRepository : IRepository<Models.Models.DriveType>
    {
        void Update(Models.Models.DriveType driveType);

    }
}
