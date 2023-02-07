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

        [HttpGet]
        public async Task<ActionResult<List<HomePageCard>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HomePageCard>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //[HttpPost]
        //public async Task<ActionResult<HomePageCard>> CreateAsync(HomePageCard product)
        //{
        //    var newProduct = await _productRepository.CreateAsync(product);
        //    return CreatedAtAction(nameof(GetByIdAsync), new { id = newProduct.id }, newProduct);
        //}
        [HttpPost("CreateAsync/{cardTitle}/{dayRange}/{cardTotal}/{cardTotalDetail}/{cardTotalStatus}")]
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


        [HttpPut("{id}")]
        public async Task<ActionResult<HomePageCard>> UpdateAsync(int id, HomePageCard product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            //var updatedProduct = await _productRepository.UpdateAsync(product);
            //return Ok(updatedProduct);
            await _productRepository.UpdateAsync(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
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
