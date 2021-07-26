using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Chocobits.Models
{
    

    public class AddProductViewModel
    {
        public Product Product { get; set; }
        [Required]
        public string PriceString { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public IFormFile ProductImage { get; set; }
    }
}
