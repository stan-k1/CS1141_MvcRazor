using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Domain;
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

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id==id);
        }
    }
}
