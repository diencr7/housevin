using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseVin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HouseVin.ViewModels;
using HouseVin.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouseVin.Controllers
{
    public class HouseInfoController : Controller
    {
        private readonly ILogger<HouseInfoController> _logger;
        private readonly HouseDbContext _context;

        public readonly IWebHostEnvironment _webHostEnvironmemnt;

        public HouseInfoController(ILogger<HouseInfoController> logger, HouseDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironmemnt = webHostEnvironment;
        }

        public async Task<IActionResult> Index(
             string searchString,
             string currentFilter,
             int? pageNumber)
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFillter"] = searchString;

            var house = from h in _context.t_HouseInfo
                        select h;

            int pageSize = 10;

            return View(await PaginatedList<t_houseInfo>.CreateAsync(house.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HouseInfoModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueThumbnailName = UploadedFile.UploadedImage(_webHostEnvironmemnt, model.Thumbnail);
                string uniqueImageBackgroundName = UploadedFile.UploadedImage(_webHostEnvironmemnt, model.ImageBackground);
                string uniqueImagesName = "";

                for (var i = 0; i < model.Images.Count; i++){
                    uniqueImagesName += UploadedFile.UploadedImage(_webHostEnvironmemnt, model.Images[i]) + ";"; 
                }

                t_houseInfo obj = new t_houseInfo
                {
                    HouseName = model.HouseName,
                    HouseAcreage = model.HouseAcreage,
                    HouseAreas = model.HouseAreas,
                    HousePrice = model.HousePrice,
                    Description = model.Description,
                    Direction = model.Direction,
                    Thumbnail = uniqueThumbnailName,
                    ImageBackground  = uniqueImageBackgroundName,
                    Imgages = uniqueImagesName
                };

                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            t_houseInfo obj = await _context.t_HouseInfo.Where(s => s.Id == id).FirstOrDefaultAsync();
            
            ViewData["HouseInfo"] = obj;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HouseInfoModel model)
        {

            return RedirectToAction(nameof(Index));
        }
    }
}