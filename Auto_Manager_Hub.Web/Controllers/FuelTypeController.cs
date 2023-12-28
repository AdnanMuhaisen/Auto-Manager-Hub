using Auto_Manager_Hub.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Manager_Hub.Web.Controllers
{
    public class FuelTypeController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; } = null!;

        public FuelTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var fuelTypes = _unitOfWork
                .FuelTypeRepository
                .GetAll()
                .ToList();

            return View(fuelTypes);
        }
    }
}
