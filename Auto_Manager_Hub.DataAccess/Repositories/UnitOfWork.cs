using Auto_Manager_Hub.DataAccess.Data;

namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _context { get; set; }
        public IBodyRepository BodyRepository { get; set; } = null!;
        public IDriveTypeRepository DriveTypeRepository { get; set; }
        public IFuelTypeRepository FuelTypeRepository { get; set; }
        public IMakeRepository MakeRepository { get; set; }
        public IMakeModelRepository MakeModelRepository {get;set; }
        public ISubModelRepository SubModelRepository { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            BodyRepository = new BodyRepository(context);
            DriveTypeRepository = new DriveTypeRepository(context);
            FuelTypeRepository = new FuelTypeRepository(context);
            MakeRepository = new MakeRepository(context);
            MakeModelRepository = new MakeModelRepository(context);
            SubModelRepository = new SubModelRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
