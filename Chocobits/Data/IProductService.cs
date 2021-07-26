using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chocobits.Data
{
    interface IProductService
    {
        public Task<List<string>> GetCategoryNames();
    }
}
