using LandScapeAPI.Models;

namespace LandScapeAPI.Repo
{
    public interface ICustomerDetailsRepository
    {
        Task<List<CustomerDetails>> GetAllAsync();
        Task<CustomerDetails> GetByIdAsync(int id);
        Task<CustomerDetails> CreateAsync(CustomerDetails detail);
        Task UpdateAsync(CustomerDetails detail);
        Task DeleteAsync(CustomerDetails detail);
    }
}
