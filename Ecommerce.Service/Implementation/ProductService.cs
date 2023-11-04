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
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _modelRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> modelrepository, IMapper mapper)
        {
            _modelRepository = modelrepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Product>(model);
                var rspModel = await _modelRepository.Create(dbModel);

                if (rspModel.IdProduct != 0)
                    return _mapper.Map<ProductDTO>(rspModel);
                else throw new TaskCanceledException("Cant create product");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditProduct(ProductDTO model)
        {
            try
            {
                var query = _modelRepository.Read(p => p.IdProduct == model.IdProduct);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Name = model.Name;
                    fromDbModel.Description = model.Description;
                    fromDbModel.IdCategory = model.IdCategory;
                    fromDbModel.Price = model.Price;
                    fromDbModel.PriceOffer = model.PriceOffer;
                    fromDbModel.Amount = model.Amount;
                    fromDbModel.Image = model.Image;

                    var resp = await _modelRepository.Update(fromDbModel);

                    if (!resp)
                        throw new TaskCanceledException("Could not edit product");
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

        public async Task<List<ProductDTO>> GetCatalogtList(string category, string search)
        {
            try
            {
                var query = _modelRepository.Read(p =>
                p.Name.ToLower().Contains(search.ToLower()) &&
                p.IdCategoryNavigation.Name.ToLower().Contains(search.ToLower())
                );

                List<ProductDTO> list = _mapper.Map<List<ProductDTO>>(await query.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            try
            {
                var query = _modelRepository.Read(p => p.IdProduct == id);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<ProductDTO>(fromDbModel);
                else throw new TaskCanceledException("No results found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> GetProductList(string search)
        {
            try
            {
                var query = _modelRepository.Read(p =>
                p.Name.ToLower().Contains(search.ToLower()) 
                );

                query = query.Include(c => c.IdCategoryNavigation);

                List<ProductDTO> list = _mapper.Map<List<ProductDTO>>(await query.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveProduct(int id)
        {

            try
            {
                var query = _modelRepository.Read(p => p.IdProduct == id);
                var fromDbModel = await query.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var resp = await _modelRepository.Delete(fromDbModel);
                    if (!resp)
                        throw new TaskCanceledException("Could not delete product");

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
