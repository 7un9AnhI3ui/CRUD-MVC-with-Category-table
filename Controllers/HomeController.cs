using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
