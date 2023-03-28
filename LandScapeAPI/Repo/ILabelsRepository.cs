using LandScapeAPI.Models;

namespace LandScapeAPI.Repo
{
    public interface ILabelsRepository
    {
        Task<List<Labels>> GetAllAsync();
        Task<Labels> GetByIdAsync(int id);
        Task<Labels> CreateAsync(Labels labelsInfo);
        Task UpdateAsync(Labels labelsInfo);
        Task DeleteAsync(Labels labelsInfo);
    }
}
