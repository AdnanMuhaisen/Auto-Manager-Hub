using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Auto_Manager_Hub.Models.Models
{

    public class Body
    {
        [Key]
        public int BodyId { get; set; }

        [Required,MaxLength(50)]
        public string BodyName { get; set; } = null!;

        [ValidateNever]
        public virtual ICollection<VehicleDetail> TblVehicleDetails { get; set; } = new List<VehicleDetail>();
    }
}
