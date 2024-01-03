using Auto_Manager_Hub.DataAccess.Repositories;
using Auto_Manager_Hub.Models.Models;
using Auto_Manager_Hub.Utility.Excel;
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
                .GetAll(AsNoTracking: true)
                .ToList();

            return View(fuelTypes);
        }

        [HttpGet]
        public IActionResult Upsert(int? ID)
        {
            if (ID == 0 || ID is null)
            {
                //create
                return View(new FuelType());
            }
            else
            {
                //update
                var fuelType = _unitOfWork
                    .FuelTypeRepository
                    .Get(f => f.FuelTypeId == ID);

                if(fuelType is null)
                {
                    throw new InvalidOperationException(nameof(fuelType));
                }

                return View(fuelType);
            }
        }

        [HttpPost]
        public IActionResult Upsert(FuelType fuelType)
        {
            ArgumentNullException.ThrowIfNull(nameof(fuelType));

            if (ModelState.IsValid)
            {
                if(fuelType.FuelTypeId == 0)
                {
                    //create
                    _unitOfWork.FuelTypeRepository.Add(fuelType);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    //update
                    _unitOfWork.FuelTypeRepository.Update(fuelType);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                //error
                ModelState.AddModelError("FuelTypeName", "Enter A Valid Fuel Type");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Remove(int? ID)
        {
            ArgumentNullException.ThrowIfNull(nameof(ID));

            if(ID == 0)
            {
                throw new ArgumentNullException(nameof(ID));
            }

            var fuelType = _unitOfWork
                .FuelTypeRepository
                .Get(f => f.FuelTypeId == ID);

            return View(fuelType);
        }

        [HttpPost,ActionName("Remove")]
        public IActionResult RemovePost(int? ID)
        {
            ArgumentNullException.ThrowIfNull(nameof(ID));

            if(ID == 0)
            {
                throw new ArgumentNullException(nameof(ID));
            }

            var fuelType = _unitOfWork
                .FuelTypeRepository
                .Get(f => f.FuelTypeId == ID);

            if(fuelType is null)
            {
                throw new InvalidOperationException(nameof(fuelType));
            }

            _unitOfWork
                .FuelTypeRepository
                .Remove(fuelType);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GenerateExcel()
        {
            var fuelTypes = _unitOfWork
                .FuelTypeRepository
                .GetAll(AsNoTracking: true);

            ExcelSheetGenerator.GenerateFor(fuelTypes);

            return View("Index", fuelTypes);
        }
    }
}
