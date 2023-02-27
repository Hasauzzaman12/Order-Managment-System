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
    public class MainMenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMainMenu _mainMenu;

        public MainMenuController(ApplicationDbContext context, IMainMenu mainMenu)
        {
            _context = context;
            _mainMenu = mainMenu;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            return View(await _mainMenu.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Module"] = new SelectList(_context.Modules, "ModuleId", "ModuleName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MainMenu mainMenu)
        {
            var data = await _mainMenu.GetByName(mainMenu.MainMenuName);
            if (data != null)
            {
                ViewBag.Message = data.MainMenuName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _mainMenu.CreateData(mainMenu);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Module"] = new SelectList(_context.Modules, "ModuleId", "ModuleName");

            return View(await _mainMenu.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MainMenu mainMenu)
        {
            var data = await _mainMenu.GetByName(mainMenu.MainMenuName);
            if (data != null)
            {
                ViewBag.Message = data.MainMenuName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _mainMenu.EditData(mainMenu);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mainMenu.DetailsData(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MainMenu mainMenu)
        {

            await _mainMenu.DeleteData(mainMenu);

            return RedirectToAction("Index");
        }
    }
}
