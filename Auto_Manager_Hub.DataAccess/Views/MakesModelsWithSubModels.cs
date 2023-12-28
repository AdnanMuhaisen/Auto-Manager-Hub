using Microsoft.EntityFrameworkCore;

namespace Auto_Manager_Hub.DataAccess.Views
{
    [Keyless]
    public class MakesModelsWithSubModels
    {
        public int MakeID { get; set; }
        public string MakeName { get; set; } = null!;
        public string ModelName { get; set; } = null!;
        public string SubModelName { get; set; } = null!;
    }
}
