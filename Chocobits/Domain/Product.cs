using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chocobits.Domain
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A product's name cannot be blank.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageLoc { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
