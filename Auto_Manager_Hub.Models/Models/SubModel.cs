namespace Auto_Manager_Hub.Models.Models
{

    public class SubModel
    {
        public int SubModelId { get; set; }

        public int ModelId { get; set; }

        public string SubModelName { get; set; } = null!;

        public virtual MakeModel Model { get; set; } = null!;

        public virtual ICollection<VehicleDetail> TblVehicleDetails { get; set; } = new List<VehicleDetail>();
    }
}
