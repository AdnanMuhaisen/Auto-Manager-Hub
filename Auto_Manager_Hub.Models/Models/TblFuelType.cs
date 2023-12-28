namespace Auto_Manager_Hub.Models.Models
{

    public class TblFuelType
    {
        public int FuelTypeId { get; set; }

        public string FuelTypeName { get; set; } = null!;

        public virtual ICollection<TblVehicleDetail> TblVehicleDetails { get; set; } = new List<TblVehicleDetail>();
    }
}
