using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.Contract;
using Ecommerce.DTO;
using Ecommerce.Service.Implementation;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        //Edit Dashboard
        [HttpGet("Resume")]
        public IActionResult Resume()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = _dashboardService.Resume();
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
