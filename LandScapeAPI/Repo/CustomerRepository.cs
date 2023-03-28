using LandScapeAPI.Models;
using LandScapeAPI.Utility;
using Microsoft.EntityFrameworkCore;

namespace LandScapeAPI.Repo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ProductDbContext _dbContext;

        public CustomerRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Customers> CreateAsync(Customers customerInfo)
        {
            _dbContext.Customers.Add(customerInfo);
            await _dbContext.SaveChangesAsync();
            return customerInfo;
        }

        public async Task DeleteAsync(Customers customerInfo)
        {
            _dbContext.Customers.Remove(customerInfo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Customers>> GetAllAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customers> GetByIdAsync(int id)
        {
            return await _dbContext.Customers.SingleOrDefaultAsync(p => p.id == id);
        }

        public async Task UpdateAsync(Customers customerInfo)
        {
            _dbContext.Customers.Update(customerInfo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
