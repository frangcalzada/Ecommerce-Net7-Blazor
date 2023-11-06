using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            //httpClient is conf in program.cs
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoryDTO>> CreateCategory(CategoryDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Category/CreateCategory", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoryDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> EditCategory(CategoryDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Category/EditCategory", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<CategoryDTO>> GetCategory(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoryDTO>>($"Category/GetCategory/{id}");
        }

        public async Task<ResponseDTO<List<CategoryDTO>>> GetCategoryList(string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoryDTO>>>($"Category/GetCategoryList/{search}");
        }

        public async Task<ResponseDTO<bool>> RemoveCategory(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Category/RemoveCategory/{id}");
        }
    }
}
