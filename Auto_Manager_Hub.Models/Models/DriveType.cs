namespace Auto_Manager_Hub.Models.Models
{

    public class DriveType

    {
        public int DriveTypeId { get; set; }

        public string DType { get; set; } = null!;

        public virtual ICollection<VehicleDetail> VehicleDetails { get; set; } = new List<VehicleDetail>();
    }
}
