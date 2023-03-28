using LandScapeAPI.Models;
using LandScapeAPI.Utility;
using Microsoft.EntityFrameworkCore;

namespace LandScapeAPI.Repo
{
    public class CustomerDetailsRepository : ICustomerDetailsRepository
    {
        private readonly ProductDbContext _dbContext;

        public CustomerDetailsRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<CustomerDetails> CreateAsync(CustomerDetails detail)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CustomerDetails detail)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerDetails>> GetAllAsync()
        {
            return await _dbContext.CustomerDetails.ToListAsync();
        }

        public Task<CustomerDetails> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomerDetails detail)
        {
            throw new NotImplementedException();
        }
    }
}
