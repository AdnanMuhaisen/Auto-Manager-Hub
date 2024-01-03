using Auto_Manager_Hub.DataAccess.Repositories;
using Auto_Manager_Hub.Utility.Excel;
using Microsoft.AspNetCore.Mvc;
using DTModel = Auto_Manager_Hub.Models.Models.DriveType;


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
                .GetAll(AsNoTracking: true)
                .ToList();

            return View(driveTypes);
        }

        [HttpGet]
        public IActionResult Upsert(int? ID)
        {
            if(ID is null || ID == 0)
            {
                //Create
                DTModel driveType = new DTModel();
                return View(driveType);
            }
            else
            {
                //Update
                var body = _unitOfWork
                    .DriveTypeRepository
                    .Get(d => d.DriveTypeId == ID);

                ArgumentNullException.ThrowIfNull(body);

                return View(body);
            }
        }

        [HttpPost]
        public IActionResult Upsert(DTModel driveType)
        {
            if (ModelState.IsValid)
            {
                if(driveType.DriveTypeId == 0)
                {
                    //Create
                    _unitOfWork
                        .DriveTypeRepository
                        .Add(driveType);

                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    //Update
                    _unitOfWork
                        .DriveTypeRepository
                        .Update(driveType);

                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                //Error
                ModelState.AddModelError("DType", "Enter A Valid Drive Type");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Remove(int? ID)
        {
            ArgumentNullException.ThrowIfNull(nameof(ID));

            var driveType = _unitOfWork
                .DriveTypeRepository
                .Get(d => d.DriveTypeId == ID);

            if(driveType is null)
            {
                throw new NullReferenceException(nameof(driveType));
            }

            return View(driveType);
        }

        [HttpPost,ActionName("Remove")]
        public IActionResult RemovePost(int? ID)
        {
            ArgumentNullException.ThrowIfNull(ID);

            var driveType = _unitOfWork
                .DriveTypeRepository
                .Get(d => d.DriveTypeId == ID);

            if(driveType is null)
            {
                throw new InvalidOperationException(nameof(driveType));
            }

            _unitOfWork
                .DriveTypeRepository
                .Remove(driveType);

            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GenerateExcel()
        {
            var driveTypes = _unitOfWork
                .DriveTypeRepository
                .GetAll(AsNoTracking: true);

            ExcelSheetGenerator.GenerateFor(driveTypes);

            return View("Index", driveTypes);
        }
    }
}
