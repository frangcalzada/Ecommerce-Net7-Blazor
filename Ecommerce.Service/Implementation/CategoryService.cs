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
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _modelRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateCategory(CategoryDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Category>(model);
                var rspModel = await _modelRepository.Create(dbModel);

                if (rspModel.IdCategory != 0)
                    return _mapper.Map<CategoryDTO>(rspModel);
                else throw new TaskCanceledException("Cant create category");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditCategory(CategoryDTO model)
        {
            try
            {
                var query = _modelRepository.Read(p => p.IdCategory == model.IdCategory);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Name = model.Name;
                    var resp = await _modelRepository.Update(fromDbModel);

                    if (!resp)
                        throw new TaskCanceledException("Could not edit category");
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

        public async Task<CategoryDTO> GetCategory(int id)
        {
            try
            {
                var query = _modelRepository.Read(p => p.IdCategory == id);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<CategoryDTO>(fromDbModel);
                else throw new TaskCanceledException("No results found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryDTO>> GetCategoryList(string search)
        {
            try
            {
                var query = _modelRepository.Read(p =>
                string.Concat(p.Name.ToLower()).Contains(search.ToLower())
                );

                List<CategoryDTO> list = _mapper.Map<List<CategoryDTO>>(await query.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveCategory(int id)
        {
            try
            {
                var query = _modelRepository.Read(p => p.IdCategory == id);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var resp = await _modelRepository.Delete(fromDbModel);
                    if (!resp)
                        throw new TaskCanceledException("could not delete category");

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