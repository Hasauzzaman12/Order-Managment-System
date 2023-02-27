using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using OMS.Interface;
using OMS.Data;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class ModuleController : Controller
    {
        private readonly IModule _module ;

        public ModuleController(IModule module)
        {
            _module = module;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _module.GetAll());
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Module module)
        {
            var data = await _module.GetByName(module.ModuleName);
            if (data != null)
            {
                ViewBag.Message = data.ModuleName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _module.CreateData(module);
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _module.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Module module)
        {
            var data = await _module.GetByName(module.ModuleName);
            if (data != null)
            {
                ViewBag.Message = data.ModuleName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _module.EditData(module);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _module.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Module module)
        {

            await _module.DeleteData(module);

            return RedirectToAction("Index");
        }

    }
}
