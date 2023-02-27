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
    public class CompanyController : Controller
    {
        private readonly ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _company.GetAll();

            return View(data);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            var data = await _company.GetByName(company.CompanyName);
            if (data != null)
            {
                ViewBag.Message = data.CompanyName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _company.CreateData(company);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _company.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Company company)
        {
            var data = await _company.GetByName(company.CompanyName);

            if (data != null)
            {
                ViewBag.Message = data.CompanyName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _company.EditData(company);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _company.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Company company)
        {

            await _company.DeleteData(company);

            return RedirectToAction("Index");
        }
    }
}
