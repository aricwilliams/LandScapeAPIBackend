using LandScapeAPI.Models;

namespace LandScapeAPI.Repo
{
    public interface IInvoice
    {
            Task<List<InvoiceM>> GetAllAsync();
            Task<InvoiceM> GetByIdAsync(int id);
            Task<InvoiceM> CreateAsync(InvoiceM invoice);
            Task UpdateAsync(InvoiceM invoice);
            Task DeleteAsync(InvoiceM invoice);
        
    }
}
