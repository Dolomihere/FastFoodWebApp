using Assignment_NET104.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET104.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _context;
        public OrderController(IOrder context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
