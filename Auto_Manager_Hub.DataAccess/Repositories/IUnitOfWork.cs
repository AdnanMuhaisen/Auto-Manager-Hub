namespace Auto_Manager_Hub.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        public IBodyRepository BodyRepository { get;  }
        public IDriveTypeRepository DriveTypeRepository { get;  }
        public IFuelTypeRepository FuelTypeRepository { get;  }
        public IMakeRepository MakeRepository { get;  }
        public IMakeModelRepository MakeModelRepository { get;  }
        public ISubModelRepository SubModelRepository { get;  }

        void Save();
    }
}
