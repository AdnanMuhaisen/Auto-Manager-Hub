namespace Auto_Manager_Hub.Models.Models
{
    public class TblMake
    {
        public int MakeId { get; set; }

        public string Make { get; set; } = null!;

        public virtual ICollection<TblMakeModel> TblMakeModels { get; set; } = new List<TblMakeModel>();
    }
}