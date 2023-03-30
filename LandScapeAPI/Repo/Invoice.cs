using LandScapeAPI.Models;
using LandScapeAPI.Utility;
using Microsoft.EntityFrameworkCore;

namespace LandScapeAPI.Repo
{
    public class Invoice : IInvoice
    {
        private readonly ProductDbContext _dbContext;

        public Invoice(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InvoiceM>> GetAllAsync()
        {
            return await _dbContext.Invoices.ToListAsync();
        }

        public async Task<InvoiceM> GetByIdAsync(int id)
        {
            return await _dbContext.Invoices.FindAsync(id);
        }

        public async Task<InvoiceM> CreateAsync(InvoiceM invoice)
        {
            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();
            return invoice;
        }

        public async Task UpdateAsync(InvoiceM invoice)
        {
            _dbContext.Entry(invoice).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(InvoiceM invoice)
        {
            _dbContext.Invoices.Remove(invoice);
            await _dbContext.SaveChangesAsync();
        }
    }
}
