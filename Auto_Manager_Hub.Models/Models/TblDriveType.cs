namespace Auto_Manager_Hub.Models.Models
{

    public class TblDriveType
    {
        public int DriveTypeId { get; set; }

        public string DType { get; set; } = null!;

        public virtual ICollection<TblVehicleDetail> TblVehicleDetails { get; set; } = new List<TblVehicleDetail>();
    }
}
