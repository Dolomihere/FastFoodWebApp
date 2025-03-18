using Assignment_NET104.Models;
using Assignment_NET104.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET104.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _context;
        public CartController(ICart context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userClaim = User.Claims.FirstOrDefault(c => c.Type == "sub");

                if (userClaim != null)
                {
                    var getCartItem = _context.ViewCart(userClaim.Value);
                    return View(getCartItem);
                }
            }
            else if (Request.Cookies["SessionId"] != null)
            {
                var getCartItem = _context.ViewCart(Request.Cookies["SessionId"]);
                return View(getCartItem);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] FoodItem item)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userClaim = User.Claims.FirstOrDefault(c => c.Type == "sub");

                _context.AddToCart(userClaim.Value, new CartItem
                {
                    FoodItemId = item.FoodItemId,
                    FoodItemImage = item.ImagePath,
                    FoodItemName = item.Name,
                    Quantity = 1,
                    Price = item.Price,
                    FoodItem = item
                });
                return Json(new { status = "success" });
            }
            else if (Request.Cookies["SessionId"] != null)
            {
                _context.AddToCart(Request.Cookies["SessionId"], new CartItem
                {
                    FoodItemId = item.FoodItemId,
                    FoodItemImage = item.ImagePath,
                    FoodItemName = item.Name,
                    Quantity = 1,
                    Price = item.Price,
                    FoodItem = item
                });
                return Json(new { status = "success" });
            }
            return Json(new { status = "failed" });
        }

        [HttpPut]
        public IActionResult UpdateCart(FoodItem item)
        {
            return View();
        }

        [HttpDelete]
        public IActionResult RemoveItem(int foodItemId)
        {
            return View();
        }
    }
}
