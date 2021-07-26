using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Chocobits.Data
{
    public class ProductService : IProductService
    {
        private readonly ChocoContext _context;

        public ProductService(ChocoContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetCategoryNames()
        {
           return await _context.Categories.Select(c => c.Name).ToListAsync();
        }
    }
}
