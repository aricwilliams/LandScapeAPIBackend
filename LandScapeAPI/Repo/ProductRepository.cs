using LandScapeAPI.Models;
using LandScapeAPI.Utility;
using Microsoft.EntityFrameworkCore;

namespace LandScapeAPI.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HomePageCard>> GetAllAsync()
        {
            return await _dbContext.HomePageCard.ToListAsync();
        }

        public async Task<HomePageCard> GetByIdAsync(int id)
        {
            return await _dbContext.HomePageCard.SingleOrDefaultAsync(p => p.id == id);
        }

        public async Task<HomePageCard> CreateAsync(HomePageCard product)
        {
            _dbContext.HomePageCard.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(HomePageCard product)
        {
            _dbContext.HomePageCard.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(HomePageCard product)
        {
            _dbContext.HomePageCard.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }


}
