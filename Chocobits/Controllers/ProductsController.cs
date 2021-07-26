using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Data;
using Chocobits.Domain;
using Chocobits.Models;
using Microsoft.AspNetCore.Hosting;

namespace Chocobits.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ChocoContext _context;

        public ProductsController(IWebHostEnvironment environment, ChocoContext context)
        {
            _environment = environment;
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction( "Index", "Home");
        }

        public IActionResult Details(int id)
        {
            Product product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            ProductDetailsViewModel model = new() {Product = product, Environment = _environment};
            return View(model);
        }
    }
}
