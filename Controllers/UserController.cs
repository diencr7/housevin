using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HouseVin.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HouseVin.ViewModels;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouseVin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly HouseDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(ILogger<UserController> logger,
            HouseDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            List<IdentityUser> lstUser = await _userManager.Users.ToListAsync();
            IDictionary<IdentityUser, IList<string>> dicUser = new Dictionary<IdentityUser, IList<string>>();
            foreach(var user in lstUser)
            {
                IList<string> role = await _userManager.GetRolesAsync(user);
                dicUser.Add(user, role);
            }
            
            return View(dicUser);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = userModel.Name,
                    Email = userModel.Email
                };
                
                var chkUser = await _userManager.FindByEmailAsync(userModel.Email);
                if(chkUser == null)
                {
                    var creUser = await _userManager.CreateAsync(user, userModel.Password);
                    if (creUser.Succeeded)
                    {
                        if (userModel.Role == true)
                        {
                            await _userManager.AddToRoleAsync(user, "Admin");
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, "Member");
                        }
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    ViewBag["EmailExits"] = "Email is exist!";
                }
                
            }
            return View();
        }
    }
}
