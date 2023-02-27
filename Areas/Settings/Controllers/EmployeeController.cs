using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OMS.Interface;
using OMS.Data;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployee _employee;

        public EmployeeController(ApplicationDbContext context, IEmployee employee)
        {
            _context = context;
            _employee = employee;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            return View(await _employee.GetAll());
        }
        
        [HttpGet]
        public async Task <IActionResult> Details(int id)
        {
            var data = await _employee.DetailsData(id);

            return View(data);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationName");

            return View();
        }
        
        [HttpPost]
        public async Task <IActionResult> Create(Employee employee)
        {
            var data = await _employee.GetByName(employee.EmpIdCardNo);
            if (data != null)
            {
                ViewBag.Message = data.EmployeeName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _employee.CreateData(employee);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["DesignationId"] = new SelectList(_context.Designations, "DesignationId", "DesignationName");

            return View(await _employee.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            var data = await _employee.GetByName(employee.EmpIdCardNo);
            if (data != null)
            {
                ViewBag.Message = data.EmpIdCardNo + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _employee.EditData(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _employee.DetailsData(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {

            await _employee.DeleteData(employee);

            return RedirectToAction("Index");
        }
    }
}
