using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HouseVin.Models;
using Microsoft.AspNetCore.Authorization;
using HouseVin.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseVin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HouseDbContext _context;

        public HomeController(ILogger<HomeController> logger, HouseDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(
            string searchString,
            string currentFilter,
            int? pageNumber)
        {
            if(searchString != null)
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

            int pageSize = 9;

            return View(await PaginatedList<t_houseInfo>.CreateAsync(house.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Search(string searchMaNha, int? pageNumber)
        {
            var house = from h in _context.t_HouseInfo
                        where h.HouseName.Contains(searchMaNha)
                        select h;
            int pageSize = 9;
            return View(await PaginatedList<t_houseInfo>.CreateAsync(house.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Detail(int id)
        {
            t_houseInfo obj = await _context.t_HouseInfo.Where(s => s.Id == id).FirstOrDefaultAsync();
            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
