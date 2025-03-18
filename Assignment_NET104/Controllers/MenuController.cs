using Assignment_NET104.Models;
using Assignment_NET104.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET104.Controllers
{
    public class MenuController : Controller
    {
        private readonly IFoodItem _food;
        private readonly ICart _cart;
        public MenuController(IFoodItem food, ICart cart)
        {
            _food = food;
            _cart = cart;
        }

        [HttpGet]
        public IActionResult Home()
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (Request.Cookies["SessionId"] == null)
                {
                    var userId = Guid.NewGuid().ToString();

                    CookieOptions options = new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddHours(1),
                        MaxAge = TimeSpan.FromHours(1),
                        HttpOnly = true,
                        Secure = true
                    };

                    Response.Cookies.Append("SessionId", userId, options);

                    _cart.CreateNew(new Cart
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        SessionId = userId
                    });
                }
            }
            return View(_food.GetList());
        }

        [HttpGet]
        public IActionResult FoodMenu()
        {
            return View(_food.GetList());
        }

        //[HttpGet]
        //public IActionResult SearchItem(string query)
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Filter(int filter)
        //{
        //    return View();
        //}
    }
}
