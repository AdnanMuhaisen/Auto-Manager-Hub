﻿using Auto_Manager_Hub.DataAccess.Data;
using Auto_Manager_Hub.Models.Models;
using Auto_Manager_Hub.Utility.Excel;
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
            //error here
            var makeModels = _context
                .fnGetMakeModels(MakeID)
                .ToList();

            if (makeModels.Count() > 0)
            {
                TempData["MakeName"] = makeModels.FirstOrDefault()?.Make_Name;
            }

            //if (TempData["MakeName"] is null)
            //{
            //    return NotFound();
            //}

            return View(makeModels);
        }

        [HttpGet]
        public IActionResult GenerateExcel(int? ID)
        {
            ArgumentNullException.ThrowIfNull(nameof(ID));

            var makeModels = _context
                .fnGetMakeModels(ID ?? 0)
                .ToList();

            ExcelSheetGenerator.GenerateFor(makeModels);

            return View("Index", makeModels);
        }
    }
}
