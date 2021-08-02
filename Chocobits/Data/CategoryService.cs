using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Domain;
using Microsoft.EntityFrameworkCore;

namespace Chocobits.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly ChocoContext _context;

        public CategoryService(ChocoContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.Include(c => c.Products).SingleOrDefaultAsync(c => c.Id==id);
        }

        public async Task<List<string>> GetCategoryNames()
        {
            return await _context.Categories.Select(c => c.Name).ToListAsync();
        }
    }
}
