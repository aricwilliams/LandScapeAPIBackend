using LandScapeAPI.Models;

namespace LandScapeAPI.Repo
{
    public interface IProductRepository
    {
        Task<List<HomePageCard>> GetAllAsync();
        Task<HomePageCard> GetByIdAsync(int id);
        Task<HomePageCard> CreateAsync(HomePageCard product);
        Task UpdateAsync(HomePageCard product);
        Task DeleteAsync(HomePageCard product);
    }

}
