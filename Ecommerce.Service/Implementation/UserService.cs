using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Model;
using Ecommerce.DTO;
using Ecommerce.Repository.Contract;
using Ecommerce.Service.Contract;
using AutoMapper;


namespace Ecommerce.Service.Implementation
{
    public class UserService: IUserService
    {
        private readonly IGenericRepository<User> _modelRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<SessionDTO> Authorization(LoginDTO model)
        {
            try
            {
                var query = _modelRepository.Read(p => p.Mail == model.Mail && p.Password == model.Password);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<SessionDTO>(fromDbModel);
                else
                    throw new TaskCanceledException("No matches found");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> CreateUser(UserDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<User>(model);
                var rspModel = await _modelRepository.Create(dbModel);

                if (rspModel.IdUser != 0)
                    return _mapper.Map<UserDTO>(rspModel);
                else throw new TaskCanceledException("Cant create user");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditUser(UserDTO model)
        {
            try
            {
                var query = _modelRepository.Read(p => p.IdUser == model.IdUser);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.FullName = model.FullName;
                    fromDbModel.Mail = model.Mail;
                    fromDbModel.Password = model.Password;
                    var resp = await _modelRepository.Update(fromDbModel);

                    if (!resp)
                        throw new TaskCanceledException("Could not edit user");
                    return resp;
                }
                else
                {
                    throw new TaskCanceledException("No results found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> GetUser(int id)
        {
            try
            {
                var query = _modelRepository.Read(p => p.IdUser == id);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if(fromDbModel != null)
                    return _mapper.Map<UserDTO>(fromDbModel);
                else throw new TaskCanceledException("No results found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDTO>> GetUserList(string rol, string search)
        {
            try
            {
                var query = _modelRepository.Read(p => 
                p.Role == rol &&
                string.Concat(p.FullName.ToLower(),p.Mail.ToLower()).Contains(search.ToLower())
                );

                List<UserDTO> list = _mapper.Map<List<UserDTO>>(await query.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveUser(int id)
        {
            try
            {
                var query = _modelRepository.Read(p => p.IdUser == id);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if (fromDbModel != null) 
                { 
                    var resp = await _modelRepository.Delete(fromDbModel);
                    if (!resp)
                        throw new TaskCanceledException("could not delete user");

                    return resp;
                }
                else
                  throw new TaskCanceledException("No results found"); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
