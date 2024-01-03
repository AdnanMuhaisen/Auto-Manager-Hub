namespace Auto_Manager_Hub.DataAccess.Functions.TVF
{
    public class MakeModelsWithSubModels
    {
        public int Make_ID { get; set; }
        public string Make_Name { get; set; } = null!;
        public string Model_Name { get; set; } = null!;
        public string SubModel_Name { get; set; } = null!;
    }
}
