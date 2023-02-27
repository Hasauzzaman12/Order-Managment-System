using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Interface;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class BrandController : Controller
    {
        private readonly IBrand _brand;

        public BrandController(IBrand brand)
        {
            _brand = brand;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _brand.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            var data = await _brand.GetByName(brand.BrandName);
            if (data != null)
            {
                ViewBag.Message = data.BrandName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _brand.CreateData(brand);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _brand.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Brand brand)
        {
            var data = await _brand.GetByName(brand.BrandName);
            if (data != null)
            {
                ViewBag.Message = data.BrandName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _brand.EditData(brand);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _brand.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Brand brand)
        {

            await _brand.DeleteData(brand);

            return RedirectToAction("Index");
        }
    }
}
