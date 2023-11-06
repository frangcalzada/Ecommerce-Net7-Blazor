using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contract
{
    public interface IUserService
    {
        Task<ResponseDTO<List<UserDTO>>> GetUserList(string rol, string search);
        Task<ResponseDTO<UserDTO>> GetUser(int id);
        Task<ResponseDTO<SessionDTO>> Authorization(LoginDTO model);
        Task<ResponseDTO<UserDTO>> CreateUser(UserDTO model);
        Task<ResponseDTO<bool>> EditUser(UserDTO model);
        Task<ResponseDTO<bool>> RemoveUser(int id);
    }
}
