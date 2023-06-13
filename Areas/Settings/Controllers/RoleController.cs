using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    //[Authorize]
    [Area("Settings")]
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;
        private readonly ISubMenu _subMenu;
        private readonly IMenu _menu;

        public RoleController(ApplicationDbContext context, IMenu menu, RoleManager<IdentityRole> roleManager, ISubMenu subMenu, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _subMenu = subMenu;
            _menu = menu;
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole()
        {
          return View(await _menu.GetAll());
        }

        [HttpGet]


        [HttpGet]
        public IActionResult Index()
        {
            var data = _roleManager.Roles.ToList();

            ViewBag.Roles = data;

            return View(data);
        }
        
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        
        [HttpPost]
        public async Task <IActionResult> Create(string name)
        {
            IdentityRole identityRole = new IdentityRole();
            identityRole.Name = name;

            var data = await _roleManager.CreateAsync(identityRole);

            return RedirectToAction("Index"); 
        }
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.Name = role.Name;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            role.Name = name;

            var exist = await _roleManager.RoleExistsAsync(role.Name);
            if (exist)
            {
                ViewBag.msg = "This role is already exist";
                ViewBag.name = name;
                return View();
            }

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.Name = role.Name;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete1(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }

    }

}
