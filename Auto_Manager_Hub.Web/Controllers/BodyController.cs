using Auto_Manager_Hub.DataAccess.Repositories;
using Auto_Manager_Hub.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Manager_Hub.Web.Controllers
{
    public class BodyController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public BodyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var bodies = _unitOfWork.BodyRepository.GetAll().ToList();
            return View(bodies);
        }       
    }
}
