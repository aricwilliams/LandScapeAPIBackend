using LandScapeAPI.Models;

namespace LandScapeAPI.Repo
{
    public interface IJobs
    {
        Task<List<JobsM>> GetAllAsync();
        Task<JobsM> GetByIdAsync(int id);
        Task<JobsM> CreateAsync(JobsM job);
        Task UpdateAsync(JobsM job);
        Task DeleteAsync(JobsM job);
    }
}
