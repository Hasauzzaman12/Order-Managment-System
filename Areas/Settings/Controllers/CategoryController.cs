using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Interface;
using OMS.Models;

namespace OMS.Areas.Product.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class CategoryController : Controller
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var data = await _category.GetAll();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var data = await _category.GetByName(category.CategoryName);
            if (data != null)
            {
                ViewBag.Message = data.CategoryName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _category.CreateData(category);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _category.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            var data = await _category.GetByName(category.CategoryName);
            if (data != null)
            {
                ViewBag.Message = data.CategoryName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _category.EditData(category);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _category.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category category)
        {
            await _category.DeleteData(category);

            return RedirectToAction("Index");
        }
    }
}
