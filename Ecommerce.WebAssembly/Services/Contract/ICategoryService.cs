using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface ICategoryService
    {
        Task<ResponseDTO<List<CategoryDTO>>> GetCategoryList(string search);
        Task<ResponseDTO<CategoryDTO>> GetCategory(int id);
        Task<ResponseDTO<CategoryDTO>> CreateCategory(CategoryDTO model);
        Task<ResponseDTO<bool>> EditCategory(CategoryDTO model);
        Task<ResponseDTO<bool>> RemoveCategory(int id);
    }
}
