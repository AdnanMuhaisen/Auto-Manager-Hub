namespace Auto_Manager_Hub.Models.Models
{

    public class MakeModel
    {
        public int ModelId { get; set; }

        public int MakeId { get; set; }

        public string ModelName { get; set; } = null!;

        public virtual Make Make { get; set; } = null!;

        public virtual ICollection<SubModel> TblSubModels { get; set; } = new List<SubModel>();
    }
}
