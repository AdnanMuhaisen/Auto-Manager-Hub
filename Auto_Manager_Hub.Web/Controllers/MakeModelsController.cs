using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Manager_Hub.Web.Controllers
{
    public class MakeModelsController : Controller
    {
        public AppDbContext _context { get; set; }

        public MakeModelsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int MakeID)
        {
            var makeModels = _context
                .fnGetMakeModels(MakeID)
                .ToList();

            if (makeModels.Count() > 0)
            {
                TempData["MakeName"] = makeModels.FirstOrDefault()?.MakeName;
            }

            if (TempData["MakeName"] is null)
            {
                return NotFound();
            }

            return View(makeModels);
        }
    }
}
