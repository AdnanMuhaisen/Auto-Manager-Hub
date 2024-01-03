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
            var bodies = _unitOfWork.BodyRepository.GetAll(AsNoTracking: true).ToList();
            return View(bodies);
        }

        [HttpGet]
        public IActionResult Upsert(int? ID)
        {
            var body = _unitOfWork
                .BodyRepository
                .Get(b => b.BodyId == ID);

            if (body is null)
            {
                body = new Body();
            }

            return View(body);
        }


        [HttpPost]
        public IActionResult Upsert(Body body)
        {
            if (ModelState.IsValid)
            {
                if(body.BodyId == 0)
                {
                    //Create
                    ArgumentNullException.ThrowIfNullOrEmpty(nameof(body.BodyName));

                    _unitOfWork
                        .BodyRepository
                        .Add(body);

                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    //Update
                    _unitOfWork
                        .BodyRepository
                        .Update(body);

                    _unitOfWork.Save();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                //Error
                ModelState.AddModelError("BodyName", "Please Enter A Valid Body Name");
                return View(body);
            }
        }

        [HttpGet]
        public IActionResult Remove(int? ID)
        {
            if(ID is null || ID == 0)
            {
                return NotFound();
            }

            var targetBody = _unitOfWork
                .BodyRepository
                .Get(b => b.BodyId == ID);

            return View(targetBody);
        }       
        
        [HttpPost,ActionName("Remove")]
        public IActionResult RemovePost(int? ID)
        {
            ArgumentNullException.ThrowIfNull(nameof(ID));

            var targetBody = _unitOfWork
                .BodyRepository
                .Get(b => b.BodyId == ID);

            ArgumentNullException.ThrowIfNull(nameof(targetBody));

            _unitOfWork
                .BodyRepository
                .Remove(targetBody!);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
