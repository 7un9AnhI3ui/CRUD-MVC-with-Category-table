using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace crud.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        /*public IActionResult Index()
        {
            var products = _context.Product.ToList();
            return View(products);
        }*/
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder)? "categoryid" : "";
            var products = from p in _context.Product
                           select p;
            switch (sortOrder)
            {
                case "categoryid":
                    products = products.OrderBy(p=>p.CategoryId);
                    break;
                default:
                    products = products.OrderBy(p=>p.Id);
                    break;
            }
            return View(await products.AsNoTracking().ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Category.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // If there's a validation error, reload the categories
            ViewBag.Categories = new SelectList(_context.Category.ToList(), "Id", "Name");
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            // Pass categories to ViewBag for the dropdown
            ViewBag.Categories = _context.Category.ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Re-populate the dropdown in case the form is invalid and redisplayed
            ViewBag.Categories = _context.Category.ToList();
            return View(product);
        }


        public IActionResult Delete(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

