using Ecommerce.Service.Contract;
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
    public class DashboardService : IDashboardService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Product> _productRepository;

        public DashboardService(ISaleRepository saleRepository,IGenericRepository<User> userRepository,IGenericRepository<Product> productRepository)
        {
            _saleRepository = saleRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        private string Incomes()
        {
            var query = _saleRepository.Read();
            decimal? totalQueryIncomes = query.Sum(x => x.Total);
            return Convert.ToString(totalQueryIncomes);
        }

        private int Sales()
        {
            var query = _saleRepository.Read();
            int totalQuerySales = query.Count();
            return totalQuerySales;
        }

        private int ClietsSales()
        {
            var query = _userRepository.Read(u => u.Role.ToLower() == "client");
            int totalClientSales = query.Count();
            return totalClientSales;
        }

        private int ProductSales()
        {
            var query = _productRepository.Read();
            int totalProdcutSales = query.Count();
            return totalProdcutSales;
        }

        public DashboardDTO Resume()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIncome = Incomes(),
                    TotalSales = Sales(),
                    TotalClients = ClietsSales(),
                    TotalProducts = ProductSales()
                };
                return dto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
