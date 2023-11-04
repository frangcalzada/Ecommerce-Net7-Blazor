using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace Ecommerce.Service.Contract
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUserList(string rol, string search);
        Task<UserDTO> GetUser(int id);
        Task<SessionDTO> Authorization(LoginDTO model);
        Task<UserDTO> CreateUser(UserDTO model);
        Task<bool> EditUser(UserDTO model);
        Task<bool> RemoveUser(int id);

    }
}
