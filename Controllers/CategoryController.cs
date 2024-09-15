using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crud.Data;
using crud.Models;

namespace crud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Category.ToList();
            return View(categories);
        }
    }
}
