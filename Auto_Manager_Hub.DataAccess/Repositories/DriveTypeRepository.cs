using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.Models.Models;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public class DriveTypeRepository : Repository<TblDriveType>, IDriveTypeRepository
    {
        public DriveTypeRepository(AppDbContext context):base(context) { }

        public void Update(TblDriveType driveType)
        {
            _context.Update(driveType);
        }
    }
}
