using Auto_Manager_Hub.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Manager_Hub.Web.Controllers
{
    public class DriveTypeController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public DriveTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var driveTypes = _unitOfWork.DriveTypeRepository
                .GetAll()
                .ToList();

            return View(driveTypes);
        }
    }
}
