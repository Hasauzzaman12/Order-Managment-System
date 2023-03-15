using Microsoft.AspNetCore.Mvc;
using OMS.Data;
using OMS.Interface;
using System.Reflection;
using OMS.Models;
using Microsoft.AspNetCore.Authorization;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class LandingController : Controller
    {
        private readonly IModule _module;
        private readonly ApplicationDbContext _context;
        
        [Obsolete]
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _he;

        [Obsolete]
        public LandingController(ApplicationDbContext context, IModule module, Microsoft.AspNetCore.Hosting.IHostingEnvironment he)
        {
            _context = context;
            _module = module;
            _he = he;
        }

        public IActionResult Index()
        {
            return View(_context.Modules.ToList());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Create(Models.Module module, IFormFile image)
        {
            if (ModelState.IsValid)
            {


                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                     //module.ModuleImageUrl= "Images/" + image.FileName;
                }

                if (image == null)
                {
                     //module.ModuleImageUrl = "Images/noimage.PNG";
                }
                _context.Modules.Add(module);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(module);
        }

    }
}
