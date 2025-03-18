using Assignment_NET104.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Assignment_NET104.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomer _customer;
        private readonly IOrder _order;
        private readonly IUser _user;
        public AccountController(ICustomer customer, IOrder order, IUser user)
        {
            _customer = customer;
            _order = order;
            _user = user;
        }

        [HttpPut]
        public IActionResult AddAccount(string name, string password)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl ?? Url.Content("~/");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string ReturnUrl)
        {
            var validate = _user.ValidateUser(email, password);

            if (validate != null)
            {
                if (!String.IsNullOrEmpty(validate.Name) && !String.IsNullOrEmpty(validate.Role))
                {
                    var claims = new List<Claim>
                    {
                        new Claim("sub", validate.UserId.ToString()),
                        new Claim(ClaimTypes.Name, validate.Name),
                        new Claim(ClaimTypes.Role, validate.Role)
                    };

                    var ci = new ClaimsIdentity(claims, "Login");
                    var cp = new ClaimsPrincipal(ci);

                    await HttpContext.SignInAsync("Login", cp);
                    return LocalRedirect(ReturnUrl != null ? ReturnUrl : Url.Content("~/"));
                }
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Menu/Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public JsonResult ProfileDetail()
        {
            var userClaim = User.Claims.FirstOrDefault(c => c.Type == "sub");

            if (userClaim != null)
            {
                int userId = int.Parse(userClaim.Value);

                var userProfile = _customer.GetUser(userId);
                var userOrder = _order.GetOrdersByCustomer(userId);

                var order = new
                {
                    user = userProfile,
                    order = userOrder
                };

                return Json(order);
            }
            return Json(new { status = "error" });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProfile()
        {
            return View();
        }
    }
}
