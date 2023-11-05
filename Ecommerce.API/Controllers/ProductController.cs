using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.Contract;
using Ecommerce.DTO; 

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Get Product List
        [HttpGet("GetProductList/{search:alpha?}")]
        public async Task<IActionResult> GetProductList(string search = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if (search == "NA")
                    search = "";

                response.IsCorrect = true;
                response.Result = await _productService.GetProductList(search);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Get Product List
        [HttpGet("GetCatalogList/{catalog:alpha}/{search:alpha?}")]
        public async Task<IActionResult> GetCatalogList(string catalog, string search = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();

            try
            {
                if (catalog.ToLower() == "all")
                    catalog = "";
                if (search == "NA")
                    search = "";

                response.IsCorrect = true;
                response.Result = await _productService.GetCatalogtList(catalog, search);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Get Product
        [HttpGet("GetProduct/{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productService.GetProduct(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Create Product
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<ProductDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productService.CreateProduct(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Edit Product
        [HttpPut("EditProduct")]
        public async Task<IActionResult> EdiProduct([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productService.EditProduct(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Remove Product
        [HttpDelete("RemoveProduct/{id:int}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _productService.RemoveProduct(id);
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
