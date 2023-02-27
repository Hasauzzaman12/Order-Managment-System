using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Interface;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class CsPersonController : Controller
    {
        private readonly ICsPerson _csPerson;

        public CsPersonController(ICsPerson csPerson)
        {
            _csPerson = csPerson;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _csPerson.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CsPerson csPerson)
        {
            var data = await _csPerson.GetByName(csPerson.CsPersonName);
            if (data != null)
            {
                ViewBag.Message = data.CsPersonName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _csPerson.CreateData(csPerson);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _csPerson.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CsPerson csPerson)
        {
            var data = await _csPerson.GetByName(csPerson.CsPersonName);
            if (data != null)
            {
                ViewBag.Message = data.CsPersonName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _csPerson.EditData(csPerson);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _csPerson.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CsPerson csPerson)
        {

            await _csPerson.DeleteData(csPerson);

            return RedirectToAction("Index");
        }
    }
}
