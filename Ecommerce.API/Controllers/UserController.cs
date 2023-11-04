using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Service.Contract;
using Ecommerce.DTO;


namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //Get User List
        [HttpGet("GetUserList/{rol:alpha}/{search:alpha?}")]
        public async Task<IActionResult> GetUserList(string rol, string search="NA")
        {
            var response = new ResponseDTO<List<UserDTO>>();

            try
            {
                if (search == "NA")
                    search = "";
                
                response.IsCorrect = true;
                response.Result = await _userService.GetUserList(rol, search);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Get User
        [HttpGet("GetUser/{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.GetUser(id);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Create User
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody]UserDTO model)
        {
            var response = new ResponseDTO<UserDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.CreateUser(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Authorization
        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] LoginDTO model)
        {
            var response = new ResponseDTO<SessionDTO>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.Authorization(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Edit User
        [HttpPut("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] UserDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.EditUser(model);
            }
            catch (Exception ex)
            {
                response.IsCorrect = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        //Remove User
        [HttpDelete("RemoveUser")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.IsCorrect = true;
                response.Result = await _userService.RemoveUser(id);
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
