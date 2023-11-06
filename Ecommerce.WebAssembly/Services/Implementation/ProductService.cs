using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            //httpClient is conf in program.cs
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<ProductDTO>> CreateProduct(ProductDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Product/CreateProduct", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> EditProduct(ProductDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Product/EditProduct", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<List<ProductDTO>>> GetCatalogtList(string category, string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/GetCatalogtList/{category}/{search}");
        }

        public async Task<ResponseDTO<ProductDTO>> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductDTO>>($"Product/GetProduct/{id}");
        }

        public async Task<ResponseDTO<List<ProductDTO>>> GetProductList(string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/GetProductList/{search}");
        }

        public async Task<ResponseDTO<bool>> RemoveProduct(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Product/RemoveProduct/{id}");
        }
    }
}
