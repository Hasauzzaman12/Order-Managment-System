using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Interface;
using OMS.Data;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class DesignationController : Controller
    {
        private readonly IDesignation _designation;

        public DesignationController(IDesignation designation)
        {
            _designation = designation;
        }
        public async Task <IActionResult> Index()
        {
            return View(await _designation.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Designation designation)
        {
            var data = await _designation.GetByName(designation.DesignationName);
            if (data != null)
            {
                ViewBag.Message = data.DesignationName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _designation.CreateData(designation);
                return RedirectToAction("Index");
            }
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _designation.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Designation designation)
        {
            var data = await _designation.GetByName(designation.DesignationName);
            if (data != null)
            {
                ViewBag.Message = data.DesignationName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _designation.EditData(designation);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _designation.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Designation designation)
        {

            await _designation.DeleteData(designation);

            return RedirectToAction("Index");
        }
    }
}
