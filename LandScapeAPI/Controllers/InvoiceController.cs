using LandScapeAPI.Models;
using LandScapeAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace LandScapeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoice _invoice;

        public InvoiceController(IInvoice invoice)
        {
            _invoice = invoice;
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceM>>> GetAllAsync()
        {
            var invoices = await _invoice.GetAllAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceM>> GetByIdAsync(int id)
        {
            var invoicee = await _invoice.GetByIdAsync(id);
            if (invoicee == null)
            {
                return NotFound();
            }

            return Ok(invoicee);
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceM>> CreateAsync(InvoiceM invoice)
        {
            var createdInvoice = await _invoice.CreateAsync(invoice);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdInvoice.Id }, createdInvoice);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InvoiceM>> UpdateAsync(int id, InvoiceM invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            var existingInvoice = await _invoice.GetByIdAsync(id);
            if (existingInvoice == null)
            {
                return NotFound();
            }

            await _invoice.UpdateAsync(invoice);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var invoicee = await _invoice.GetByIdAsync(id);
            if (invoicee == null)
            {
                return NotFound();
            }

            await _invoice.DeleteAsync(invoicee);
            return NoContent();
        }
    }
}
