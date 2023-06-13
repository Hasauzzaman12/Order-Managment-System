using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;
using OMS.ViewModel;
using System.Reflection;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IModule _module;
        private readonly IMenu _menu;

        public MenuController(IMenu menu,IModule module, ApplicationDbContext context)
        {
            _menu = menu;
            _context = context;
            _module = module;
        }

        //GET: Menu
        public async Task<IActionResult> Index()
        {
            return View(await _menu.GetAll());
        }

        //GET: Menu
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var data = new MenuViewModel
            {
                Menus = await _menu.GetAll(),
                Modules = await _module.GetAll(),
            };          
            return View(data);
        }

        //POST: Menu
        [HttpPost]
        public async Task<IActionResult> Create(MenuViewModel menu)
        {
           
            if (!ModelState.IsValid)
            {
                var menus = new Menu
                {
                    ModuleId=menu.ModuleId,
                    ParentId=menu.ParentId,
                    MenuName = menu.MenuName,
                    Description = menu.Description,
                    AreaName = menu.AreaName,
                    ControllerName = menu.ControllerName,
                    ActionName = menu.ActionName,
                    IsActive = menu.IsActive,
                };
                await _menu.CreateData(menus);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
