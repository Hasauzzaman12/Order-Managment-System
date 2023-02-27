using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Interface;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class BuyerController : Controller
    {
        private readonly IBuyer _buyer;

        public BuyerController(IBuyer buyer)
        {
            _buyer = buyer;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _buyer.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Buyer buyer)
        {
            var data = await _buyer.GetByName(buyer.BuyerName);
            if (data != null)
            {
                ViewBag.Message = data.BuyerName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _buyer.CreateData(buyer);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _buyer.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Buyer buyer)
        {
            var data = await _buyer.GetByName(buyer.BuyerName);
            if (data != null)
            {
                ViewBag.Message = data.BuyerName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _buyer.EditData(buyer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _buyer.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Buyer buyer)
        {

            await _buyer.DeleteData(buyer);

            return RedirectToAction("Index");
        }
    }
}
