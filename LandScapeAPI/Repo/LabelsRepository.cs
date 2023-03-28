using LandScapeAPI.Models;
using LandScapeAPI.Utility;
using Microsoft.EntityFrameworkCore;

namespace LandScapeAPI.Repo
{
    public class LabelsRepository : ILabelsRepository
    {
        private readonly ProductDbContext _dbContext;

        public LabelsRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Labels> CreateAsync(Labels labelsInfo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Labels labelsInfo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Labels>> GetAllAsync()
        {
            return await _dbContext.Labels.ToListAsync();
        }

        public Task<Labels> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Labels labelsInfo)
        {
            throw new NotImplementedException();
        }
    }
}
