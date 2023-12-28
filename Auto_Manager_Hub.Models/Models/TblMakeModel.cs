namespace Auto_Manager_Hub.Models.Models
{

    public class TblMakeModel
    {
        public int ModelId { get; set; }

        public int MakeId { get; set; }

        public string ModelName { get; set; } = null!;

        public virtual TblMake Make { get; set; } = null!;

        public virtual ICollection<TblSubModel> TblSubModels { get; set; } = new List<TblSubModel>();
    }
}
