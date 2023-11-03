using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model;

namespace Ecommerce.Utilities
{
    public class AutoMapperProfile: Profile
    {
        //Rules maps definitions
        public AutoMapperProfile()
        {
            //User, UserDTO and SessionDTO 
            CreateMap<User, UserDTO>();
            CreateMap<User, SessionDTO>();
            CreateMap<UserDTO, User>();

            //Category, CategoryDTO
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            //Product, ProductDTO
            CreateMap<Product, ProductDTO>();
            //IdCategoryNavigationDTO is not the same as IdCategoryNavigationProduct
            CreateMap<ProductDTO, Product>().ForMember(destination =>
                destination.IdCategoryNavigation,
                opt => opt.Ignore()
               );

            //DetailSale, DetailSaleDTO
            CreateMap<DetailSale, DetailSaleDTO>();
            CreateMap<DetailSaleDTO, DetailSale>();

            //Sale, SaleDTO
            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleDTO, Sale>();
        }
    }
}
