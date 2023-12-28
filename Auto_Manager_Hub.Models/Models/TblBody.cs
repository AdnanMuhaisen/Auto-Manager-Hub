namespace Auto_Manager_Hub.Models.Models
{

    public class TblBody
    {
        public int BodyId { get; set; }

        public string BodyName { get; set; } = null!;

        public virtual ICollection<TblVehicleDetail> TblVehicleDetails { get; set; } = new List<TblVehicleDetail>();
    }
}
