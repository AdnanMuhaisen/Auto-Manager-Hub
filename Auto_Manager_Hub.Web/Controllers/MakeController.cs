using Auto_Manager_Hub.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Manager_Hub.Web.Controllers
{
    public class MakeController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public MakeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var makes = _unitOfWork
                .MakeRepository
                .GetAll()
                .ToList();

            return View(makes);
        }
    }
}
