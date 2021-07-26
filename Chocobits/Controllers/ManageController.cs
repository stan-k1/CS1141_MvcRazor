using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Data;
using Chocobits.Domain;
using Chocobits.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Chocobits.Controllers
{
    public class ManageController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ChocoContext _context;

        public ManageController(IWebHostEnvironment appEnvironment, ChocoContext context)
        {
            _appEnvironment = appEnvironment;
            _context = context;
        }

        public IActionResult AddProduct()
        {
            return View(new AddProductViewModel()
            {
                Categories = _context.Categories
                    .Select(c=> new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, 
            [Required(ErrorMessage = "The price field cannot be blank."), RegularExpression("[0-9]+[.,]?[0-9]*")] string priceString, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {

                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_appEnvironment.WebRootPath, "assets/products");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") +
                                           Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                product.ImageLoc = fileName;
                            }

                        }
                    }
                }

                product.Price= decimal.Parse(priceString.Replace(".", ","));

                _context.Add(product);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Details", "Products", new {id = product.Id});
            }

            return View(new AddProductViewModel()
            {
                Categories = _context.Categories
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList()
            });
        }

    }
}
