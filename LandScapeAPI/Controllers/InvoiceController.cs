using LandScapeAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace LandScapeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoice _invoice;

        public InvoicesController(IInvoice invoice)
        {
            _invoice = invoice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Invoice>>> GetAllAsync()
        {
            var invoices = await _invoice.GetAllAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetByIdAsync(int id)
        {
            var invoice = await _invoice.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateAsync(Invoice invoice)
        {
            var createdInvoice = await _invoice.CreateAsync(invoice);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdInvoice.Id }, createdInvoice);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Invoice>> UpdateAsync(int id, Invoice invoice)
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
            var invoice = await _invoice.GetByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            await _invoice.DeleteAsync(invoice);
            return NoContent();
        }
    }
}
