using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Interface;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class UoMController : Controller
    {
        private readonly IUoM _uoM;

        public UoMController(IUoM uoM)
        {
            _uoM = uoM;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _uoM.GetAll();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UoM uoM)
        {
            var data = await _uoM.GetByName(uoM.UoMName);
            if (data != null)
            {
                ViewBag.Message = data.UoMName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _uoM.CreateData(uoM);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _uoM.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UoM uoM)
        {
            var data = await _uoM.GetByName(uoM.UoMName);
            if (data != null)
            {
                ViewBag.Message = data.UoMName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _uoM.EditData(uoM);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _uoM.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UoM uoM)
        {
            await _uoM.DeleteData(uoM);

            return RedirectToAction("Index");
        }

    }
}
