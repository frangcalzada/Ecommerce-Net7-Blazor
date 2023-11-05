using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.Contract;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //Get Category List
        [HttpGet("GetCategoryList/{search:alpha?}")]
        public async Task<IActionResult> GetCategoryList(string search = "NA")
        {
            var response = new ResponseDTO<List<CategoryDTO>>();

            try
            {
                if (search == "NA")
                    search = "";

                response.IsCorrect = true;
                response.Result = await _categoryService.GetCategoryList(search);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Get Category
        [HttpGet("GetCategory/{id:int}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var response = new ResponseDTO<CategoryDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoryService.GetCategory(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Create Category
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<CategoryDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoryService.CreateCategory(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Edit Category
        [HttpPut("EditCategory")]
        public async Task<IActionResult> EdiCategory([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoryService.EditCategory(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Remove Category
        [HttpDelete("RemoveCategory/{id:int}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _categoryService.RemoveCategory(id);
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
