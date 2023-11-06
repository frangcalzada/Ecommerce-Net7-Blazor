using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface IProductService
    {
        Task<ResponseDTO<List<ProductDTO>>> GetProductList(string search);
        Task<ResponseDTO<List<ProductDTO>>> GetCatalogtList(string category, string search);
        Task<ResponseDTO<ProductDTO>> GetProduct(int id);
        Task<ResponseDTO<ProductDTO>> CreateProduct(ProductDTO model);
        Task<ResponseDTO<bool>> EditProduct(ProductDTO model);
        Task<ResponseDTO<bool>> RemoveProduct(int id);
    }
}
