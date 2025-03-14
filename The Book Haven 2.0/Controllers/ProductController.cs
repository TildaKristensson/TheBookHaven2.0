using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBookHaven2.Interface;
using TheBookHaven2.Models;

namespace TheBookHaven2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery]string searchTerm = null, [FromQuery] string authorName = null)
        {
            var products = await _repository.SearchProductsAsync(searchTerm, authorName);

            if (products == null || !products.Any())
            {
                return NotFound();
                // return OK(new List<Product>()); ??
            }

            return Ok(products);
        }

        [HttpGet("isbn/{isbn}")]
        public async Task<IActionResult> GetByISBN(string isbn)
        {
            var product = await _repository.GetByISBNAsync(isbn);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableProducts()
            => Ok(await _repository.GetAvailableProductsAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _repository.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            await _repository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
