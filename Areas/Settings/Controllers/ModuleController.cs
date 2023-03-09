using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using OMS.Interface;
using OMS.Data;
using OMS.Models;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class ModuleController : Controller
    {
        private readonly IModule _module ;
        private readonly ApplicationDbContext _context;
        [Obsolete]
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _he;

        [Obsolete]
        public ModuleController(ApplicationDbContext context, IModule module, Microsoft.AspNetCore.Hosting.IHostingEnvironment he)
        {
            _context = context;
            _module = module;
            _he = he;
            
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
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Create(Module module, IFormFile image)
        {
            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    module.ModuleImageUrl = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    module.ModuleImageUrl = "Images/noimage.PNG";
                }
                await _module.CreateData(module);
                return RedirectToAction("Index");
            }

            return View(module);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Module module)
        //{
        //    var data = await _module.GetByName(module.ModuleName);

        //    if (data != null)
        //    {
        //        ViewBag.Message = data.ModuleName + " Already Exist";
        //        return View();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        if (module.ModuleImagePath != null)
        //        {
        //            var folder = "images/Module/";
        //            folder += Guid.NewGuid().ToString() + "_" + module.ModuleImagePath.FileName;
        //            module.ModuleImageUrl = folder;
        //            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

        //            await module.ModuleImagePath.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
        //        }
        //        await _module.CreateData(module);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    return View(await _module.GetById(id));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(Module module)
        //{

        //    //    var folder = "images/Module/";
        //    //    folder += Guid.NewGuid().ToString() + "_" ;
        //    //    module.ModuleImageUrl = folder;
        //    //    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

        //    //    await module.ModuleImagePath.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        //    //await _module.EditData(module);
        //    //return RedirectToAction("Index");

        //    if (module.ModuleImageUrl == null || module.ModuleImageUrl.Length == 0)
        //    {
        //        return Content("File not selected");
        //    }
        //    //Save The Picture In folder
        //    var path = Path.Combine("images/Module", module.ModuleImageUrl);
        //    using (FileStream stream = new FileStream(path, FileMode.Create))
        //    {
        //        await module.ModuleImagePath.CopyToAsync(stream);
        //        stream.Close();
        //    }

        //    //Bind Picture info to model
        //    _module.module.ModuleImageUrl.FileName;

        //    //Finding the member by its Id which we would update
        //    var objMember = _context.Members.Where(mId => mId.MemberId == model.Member.MemberId).FirstOrDefault();

        //    if (objMember != null)
        //    {
        //        //Update the existing member with new value
        //        objMember!.Name = model.Member.Name;
        //        objMember!.Gender = model.Member.Gender;
        //        objMember!.DOB = model.Member.DOB;
        //        objMember!.ImageName = model.Member.ImageName;
        //        objMember!.ImageLocation = path;

        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToAction("MemberList");


        //}

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
