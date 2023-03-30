using LandScapeAPI.Models;
using LandScapeAPI.Utility;
using Microsoft.EntityFrameworkCore;

namespace LandScapeAPI.Repo
{
    public class Jobs : IJobs
    {
        private readonly ProductDbContext _dbContext;

        public Jobs(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<JobsM>> GetAllAsync()
        {
            return await _dbContext.JobsM.ToListAsync();
        }

        public async Task<JobsM> GetByIdAsync(int id)
        {
            return await _dbContext.JobsM.FindAsync(id);
        }

        public async Task<JobsM> CreateAsync(JobsM job)
        {
            _dbContext.JobsM.Add(job);
            await _dbContext.SaveChangesAsync();
            return job;
        }

        public async Task UpdateAsync(JobsM job)
        {
            _dbContext.Entry(job).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(JobsM job)
        {
            _dbContext.JobsM.Remove(job);
            await _dbContext.SaveChangesAsync();
        }
    }
}
