using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class SubMenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISubMenu _subMenu;

        public SubMenuController(ApplicationDbContext context, ISubMenu subMenu)
        {
            _context = context;
            _subMenu = subMenu;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _subMenu.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _subMenu.DetailsData(id);

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["MainMenu"] = new SelectList(_context.MainMenus, "MainMenuId", "MainMenuName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubMenu subMenu)
        {
            var data = await _subMenu.GetByName(subMenu.SubMenuName);
            if (data != null)
            {
                ViewBag.Message = data.SubMenuName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _subMenu.CreateData(subMenu);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["MainMenu"] = new SelectList(_context.MainMenus, "MainMenuId", "MainMenuName");

            return View(await _subMenu.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubMenu subMenu)
        {
            var data = await _subMenu.GetByName(subMenu.SubMenuName);
            if (data != null)
            {
                ViewBag.Message = data.SubMenuName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _subMenu.EditData(subMenu);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _subMenu.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SubMenu subMenu)
        {

            await _subMenu.DeleteData(subMenu);

            return RedirectToAction("Index");
        }
    }
}
