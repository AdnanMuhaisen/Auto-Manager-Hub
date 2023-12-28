namespace Auto_Manager_Hub.Models.Models
{

    public class TblVehicleDetail
    {
        public int Id { get; set; }

        public int? MakeId { get; set; }

        public int? ModelId { get; set; }

        public int? SubModelId { get; set; }

        public int? BodyId { get; set; }

        public string? VehicleDisplayName { get; set; }

        public short? Year { get; set; }

        public int? DriveTypeId { get; set; }

        public string? Engine { get; set; }

        public short? EngineCc { get; set; }

        public byte? EngineCylinders { get; set; }

        public decimal? EngineLiterDisplay { get; set; }

        public int? FuelTypeId { get; set; }

        public byte? NumDoors { get; set; }

        public virtual TblBody? Body { get; set; }

        public virtual TblDriveType? DriveType { get; set; }

        public virtual TblFuelType? FuelType { get; set; }

        public virtual TblSubModel? SubModel { get; set; }
    }
}