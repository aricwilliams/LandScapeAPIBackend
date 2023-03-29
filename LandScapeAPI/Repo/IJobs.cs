namespace LandScapeAPI.Repo
{
    public interface IJobs
    {
        Task<List<Jobs>> GetAllAsync();
        Task<Jobs> GetByIdAsync(int id);
        Task<Jobs> CreateAsync(Jobs job);
        Task UpdateAsync(Jobs job);
        Task DeleteAsync(Jobs job);
    }
}
