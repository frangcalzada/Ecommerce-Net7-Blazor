using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface ISaleService
    {
        Task<ResponseDTO<SaleDTO>> Register(SaleDTO model);
    }
}
