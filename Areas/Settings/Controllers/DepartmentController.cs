using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMS.Interface;
using OMS.Data;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class DepartmentController : Controller
    {
        private readonly IDepartment _department;

        public DepartmentController(IDepartment department)
        {
            _department = department;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _department.GetAll();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            var data = await _department.GetByName(department.DepartmentName);
            if (data != null)
            {
                ViewBag.Message = data.DepartmentName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _department.CreateData(department);
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _department.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            var data = await _department.GetByName(department.DepartmentName);

            if (data != null)
            {
                ViewBag.Message = data.DepartmentName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _department.EditData(department);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _department.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Department department)
        {

            await _department.DeleteData(department);

            return RedirectToAction("Index");
        }

    }
}
