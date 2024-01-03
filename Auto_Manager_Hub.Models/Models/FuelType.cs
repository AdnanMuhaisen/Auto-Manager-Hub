namespace Auto_Manager_Hub.Models.Models
{

    public class FuelType
    {
        public int FuelTypeId { get; set; }

        public string FuelTypeName { get; set; } = null!;

        public virtual ICollection<VehicleDetail> TblVehicleDetails { get; set; } = new List<VehicleDetail>();
    }
}
