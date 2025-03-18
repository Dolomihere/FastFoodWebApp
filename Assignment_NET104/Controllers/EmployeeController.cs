using Assignment_NET104.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_NET104.Controllers
{
    [Authorize(Policy = "AdminAccess")]
    public class EmployeeController : Controller
    {
        private readonly IAdmin _context;
        public EmployeeController(IAdmin context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ManageCustomer()
        {
            return View();
        }
    }
}
