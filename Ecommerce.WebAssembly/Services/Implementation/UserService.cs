using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            //httpClient is conf in program.cs
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SessionDTO>> Authorization(LoginDTO model)
        {
            //Executing POST and sending JSON. (URL/Method, Body)
            var response = await _httpClient.PostAsJsonAsync("User/Authorization", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SessionDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<UserDTO>> CreateUser(UserDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("User/CreateUser", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UserDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> EditUser(UserDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("User/EditUser", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<UserDTO>> GetUser(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UserDTO>>($"User/GetUser/{id}");
        }

        public async Task<ResponseDTO<List<UserDTO>>> GetUserList(string rol, string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UserDTO>>>($"User/GetUserList/{rol}/{search}");
        }

        public async Task<ResponseDTO<bool>> RemoveUser(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"User/RemoveUser/{id}");
        }
    }
}
