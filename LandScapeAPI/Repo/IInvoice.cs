namespace LandScapeAPI.Repo
{
    public interface IInvoice
    {
            Task<List<Invoice>> GetAllAsync();
            Task<Invoice> GetByIdAsync(int id);
            Task<Invoice> CreateAsync(Invoice invoice);
            Task UpdateAsync(Invoice invoice);
            Task DeleteAsync(Invoice invoice);
        
    }
}
