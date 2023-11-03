using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Model;
using Ecommerce.Repository.Contract;
using Ecommerce.Repository.DBContext;

namespace Ecommerce.Repository.Implementation
{
    public class SaleRepository: GenericRepository<Sale>, ISaleRepository
    {
        private readonly DbecommerceContext _dbContext;

        public SaleRepository(DbecommerceContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Sale> Register(Sale model)
        {
            Sale newSale = new Sale();

            //init transaction
            using (var transaction = _dbContext.Database.BeginTransaction()){
                try
                {
                    //Updating Product
                    foreach(DetailSale ds in model.DetailSales)
                    {
                        Product product_found = _dbContext.Products.Where(p => p.IdProduct == ds.IdProduct).First();
                        product_found.Amount = product_found.Amount - ds.Amount;
                        _dbContext.Products.Update(product_found);
                    }
                    await _dbContext.SaveChangesAsync();

                    //Updating Sale 
                    await _dbContext.Sales.AddAsync(model);
                    await _dbContext.SaveChangesAsync();

                    newSale = model;

                    //Succesful transaction
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return newSale;
        }
    }

}
