using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Interface;
using OMS.Models;

namespace OMS.Areas.Settings.Controllers
{
    [Authorize]
    [Area("Settings")]
    public class OrderTypeController : Controller
    {
        private readonly IOrderType _orderType;

        public OrderTypeController(IOrderType orderType)
        {
            _orderType = orderType;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _orderType.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderType orderType)
        {
            var data = await _orderType.GetByName(orderType.OrderTypeName);
            if (data != null)
            {
                ViewBag.Message = data.OrderTypeName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _orderType.CreateData(orderType);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _orderType.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderType orderType)
        {
            var data = await _orderType.GetByName(orderType.OrderTypeName);
            if (data != null)
            {
                ViewBag.Message = data.OrderTypeName + " Already Exist";
                return View();
            }

            if (ModelState.IsValid)
            {
                await _orderType.EditData(orderType);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _orderType.GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OrderType orderType)
        {

            await _orderType.DeleteData(orderType);

            return RedirectToAction("Index");
        }
    }
}
