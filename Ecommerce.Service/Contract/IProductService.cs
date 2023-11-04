using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace Ecommerce.Service.Contract
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProductList(string search);
        Task<List<ProductDTO>> GetCatalogtList(string category, string search);
        Task<ProductDTO> GetProduct(int id);
        Task<ProductDTO> CreateProduct(ProductDTO model);
        Task<bool> EditProduct(ProductDTO model);
        Task<bool> RemoveProduct(int id);
    }
}
