using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Data;
using Microsoft.AspNetCore.Mvc;

namespace Chocobits.Components
{
    public class ProductsComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsComponent(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? categoryid)
        {
            if (categoryid is null)
            {
                var products = await _productService.GetAllProducts();
                return View(products);
            }
            else
            {
                var category = await _categoryService.GetCategory((int) categoryid);
                return View(category.Products);
            }
        } 
    }
}
