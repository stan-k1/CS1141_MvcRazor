using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Domain;

namespace Chocobits.Models.Products
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public List<Product> Products { get; set; }
    }
}
