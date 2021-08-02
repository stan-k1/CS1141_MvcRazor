using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chocobits.Domain;

namespace Chocobits.Data
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllCategories();
        public Task<Category> GetCategory(int id);
        public Task<List<string>> GetCategoryNames();
    }
}
