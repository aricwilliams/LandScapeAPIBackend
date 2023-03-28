using LandScapeAPI.Models;
using LandScapeAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace LandScapeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("HomePageController")]
        public async Task<ActionResult<List<HomePageCard>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("HomePageController/{id}")]
        public async Task<ActionResult<HomePageCard>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("HomePageControllerCreateAsync/{cardTitle}/{dayRange}/{cardTotal}/{cardTotalDetail}/{cardTotalStatus}")]
        public async Task<ActionResult<HomePageCard>> CreateAsync(string cardTitle, string dayRange, int cardTotal, int cardTotalDetail, string cardTotalStatus)
        {
            HomePageCard newProduct = new HomePageCard
            {
                cardTitle = cardTitle,
                dayRange = dayRange,
                cardTotal = cardTotal,
                cardTotalDetail = cardTotalDetail,
                cardTotalStatus = cardTotalStatus
            };

            var createdProduct = await _productRepository.CreateAsync(newProduct);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdProduct.id }, createdProduct);
        }


        [HttpPut("HomePageControllerUpdateHomeCards{id}/{cardTitle}/{dayRange}/{cardTotal}/{cardTotalDetail}/{cardTotalStatus}")]
        public async Task<ActionResult<HomePageCard>> UpdateAsync2(int id, string cardTitle, string dayRange, int cardTotal, int cardTotalDetail, string cardTotalStatus)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.cardTitle = cardTitle;
            product.dayRange = dayRange;
            product.cardTotal = cardTotal;
            product.cardTotalDetail = cardTotalDetail;
            product.cardTotalStatus = cardTotalStatus;
            await _productRepository.UpdateAsync(product);

            return Ok(product);
        }


        [HttpDelete("HomePageController/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteAsync(product);
            return NoContent();
        }
    }

}
