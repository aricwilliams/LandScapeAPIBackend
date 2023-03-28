using LandScapeAPI.Models;

namespace LandScapeAPI.Repo
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetAllAsync();
        Task<Customers> GetByIdAsync(int id);
        Task<Customers> CreateAsync(Customers customerInfo);
        Task UpdateAsync(Customers customerInfo);
        Task DeleteAsync(Customers customerInfo);
    }
}
