using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Domain;
using Microsoft.AspNetCore.Hosting;

namespace Chocobits.Models
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public IWebHostEnvironment Environment { get; set; }
    }
}
