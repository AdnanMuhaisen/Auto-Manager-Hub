namespace Auto_Manager_Hub.Models.Models
{

    public class TblSubModel
    {
        public int SubModelId { get; set; }

        public int ModelId { get; set; }

        public string SubModelName { get; set; } = null!;

        public virtual TblMakeModel Model { get; set; } = null!;

        public virtual ICollection<TblVehicleDetail> TblVehicleDetails { get; set; } = new List<TblVehicleDetail>();
    }
}
