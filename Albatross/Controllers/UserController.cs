using Microsoft.AspNetCore.Mvc;

namespace Albatross.Controllers;

    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
