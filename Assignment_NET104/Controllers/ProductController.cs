using Assignment_NET104.Models;
using Assignment_NET104.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET104.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IFoodItem _context;
        public ProductController(IFoodItem context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ManageProduct()
        {
            return View(_context.GetList());
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] FoodItem item)
        {
            _context.CreateNew(item);
            return View();
        }

        [HttpPut]
        public IActionResult EditItem(FoodItem item)
        {
            _context.Edit(item);
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteItem(int foodItemId)
        {
            _context.RemoveItem(foodItemId);
            return View();
        }

        [HttpGet]
        public IActionResult SearchItem(string input)
        {
            return View();
        }
    }
}
