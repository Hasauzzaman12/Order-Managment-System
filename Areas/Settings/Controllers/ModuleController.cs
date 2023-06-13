using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using OMS.Interface;
using OMS.Data;
using OMS.Models;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
//using OMS.Migrations;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class ModuleController : Controller
    {
        private readonly IModule _module;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        public ModuleController(ApplicationDbContext context, IModule module, IWebHostEnvironment webHost)
        {
            _context = context;
            _module = module;
            _webHost = webHost;
        }
        
        [HttpGet]
        public async Task<IActionResult> Landing()
        {
            return View(await _module.GetAll());
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
                if(module.ModuleImage != null)
                {
                    string folder = "Images/Module/";
                    folder += Guid.NewGuid().ToString() + "_" + module.ModuleImage.FileName;
                    string serverFolder = Path.Combine(_webHost.WebRootPath, folder);

                    await module.ModuleImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    module.ImagePath = folder;
                    
                    await _module.CreateData(module);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public async Task <IActionResult> Edit(int id)
        {
            return View(await _module.GetById(id));

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Module module)
        {
            //var data = await _module.GetByName(module.ModuleName);

            //if (data != null)
            //{
            //    ViewBag.Message = data.ModuleName + " Already Exist";
            //    return View();
            //}

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
