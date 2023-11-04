using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace Ecommerce.Service.Contract
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCategoryList(string search);
        Task<CategoryDTO> GetCategory(int id);
        Task<CategoryDTO> CreateCategory(CategoryDTO model);
        Task<bool> EditCategory(CategoryDTO model);
        Task<bool> RemoveCategory(int id);
    }
}
