using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Data;
using Chocobits.Domain;
using Chocobits.Models;
using Chocobits.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Chocobits.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ChocoContext _context;

        public ProductsController(IProductService productService, ICategoryService categoryService, ChocoContext context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _context = context;
        }

        public async Task<ActionResult<ProductsIndexViewModel>> Index()
        {
            return View(new ProductsIndexViewModel() {Categories = await _categoryService.GetAllCategories()});
        }

        [Route("{controller}/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            Product product = await _productService.GetProduct(id);
            if (product is null) return NotFound();

            ProductDetailsViewModel model = new() {Product = product};
            return View(model);
        }

        public async Task<IActionResult> Category(int id)
        {
            Category category = await _categoryService.GetCategory(id);
            return View(new CategoryViewModel()
            {
                Products = category.Products, 
                CategoryName = category.Name,
                CategoryDesc = category.Description
            });
        }

        [HttpGet, Route("{controller}/add")]
        public async Task<IActionResult> AddProduct()
        {
            return View(new AddProductViewModel()
            {
                Categories = await _context.Categories
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToListAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, IFormFile image)
        {
            if (!ModelState.IsValid) return View(new AddProductViewModel()
            {
                Categories = await _context.Categories
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToListAsync()
            });


            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {

                if (Image != null && Image.Length > 0)
                {
                    var file = Image;

                    var uploads = Path.Combine("assets/products");
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            product.ImageLoc = fileName;
                        }

                    }
                }
            }

            _context.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Products", new { id = product.Id });
        }
    }
}