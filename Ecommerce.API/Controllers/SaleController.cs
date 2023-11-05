using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.Contract;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        //Register Sale
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] SaleDTO model)
        {
            var response = new ResponseDTO<SaleDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _saleService.Register(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
