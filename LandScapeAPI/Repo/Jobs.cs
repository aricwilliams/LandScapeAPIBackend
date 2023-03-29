using LandScapeAPI.Utility;

namespace LandScapeAPI.Repo
{
    public class Jobs : IJobs
    {
        private readonly ProductDbContext _dbContext;

        public JobsRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Jobs>> GetAllAsync()
        {
            return await _dbContext.Jobs.ToListAsync();
        }

        public async Task<Jobs> GetByIdAsync(int id)
        {
            return await _dbContext.Jobs.FindAsync(id);
        }

        public async Task<Jobs> CreateAsync(Jobs job)
        {
            _dbContext.Jobs.Add(job);
            await _dbContext.SaveChangesAsync();
            return job;
        }

        public async Task UpdateAsync(Jobs job)
        {
            _dbContext.Entry(job).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Jobs job)
        {
            _dbContext.Jobs.Remove(job);
            await _dbContext.SaveChangesAsync();
        }
    }
}
