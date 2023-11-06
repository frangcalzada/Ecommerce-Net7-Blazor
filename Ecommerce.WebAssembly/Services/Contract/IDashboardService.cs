using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface IDashboardService
    {
        Task<ResponseDTO<DashboardDTO>> Resume();
    }
}
