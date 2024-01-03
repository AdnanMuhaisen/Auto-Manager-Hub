using Auto_Manager_Hub.DataAccess.Repositories;
using Auto_Manager_Hub.Models.Models;
using Auto_Manager_Hub.Utility.Excel;
using Microsoft.AspNetCore.Http.HttpResults;
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
                .GetAll(AsNoTracking: true)
                .ToList();

            return View(makes);
        }

        [HttpGet]
        public IActionResult Upsert(int? ID)
        {
            if(ID is null || ID == 0)
            {
                //create
                var make = new Make();
                return View(make);
            }
            else
            {
                //update
                var targetMake = _unitOfWork
                    .MakeRepository
                    .Get(m => m.MakeId == ID);

                if(targetMake is null)
                {
                    return NotFound();
                }

                return View(targetMake);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Make make)
        {
            if (ModelState.IsValid)
            {
                if(make.MakeId == 0)
                {
                    //create 
                    _unitOfWork
                        .MakeRepository
                        .Add(make);

                    _unitOfWork.Save();

                    return RedirectToAction("Index");
                }
                else
                {
                    _unitOfWork.MakeRepository.Update(make);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Remove(int? ID)
        {
            var make = _unitOfWork
                .MakeRepository
                .Get(m => m.MakeId == ID);

            if(make is null)
            {
                throw new NullReferenceException(nameof(make));
            }

            return View(make);
        }

        [HttpPost]
        public IActionResult Remove(int ID)
        {
            ArgumentNullException.ThrowIfNull(ID);

            var make = _unitOfWork
                .MakeRepository
                .Get(m => m.MakeId == ID);

            if(make is null)
            {
                throw new NullReferenceException(nameof(make));
            }

            _unitOfWork.MakeRepository.Remove(make);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GenerateExcel()
        {
            var makes = _unitOfWork
                .MakeRepository
                .GetAll(AsNoTracking: true);

            ExcelSheetGenerator.GenerateFor(makes);

            return View("Index", makes);
        }
    }
}
