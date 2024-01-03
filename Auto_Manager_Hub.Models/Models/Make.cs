namespace Auto_Manager_Hub.Models.Models
{
    public class Make
    {
        public int MakeId { get; set; }

        public string MakeName { get; set; } = null!;

        public virtual ICollection<MakeModel> TblMakeModels { get; set; } = new List<MakeModel>();
    }
}