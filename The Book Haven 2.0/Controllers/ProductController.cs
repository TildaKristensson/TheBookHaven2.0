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
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllProductsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id can not be equal to or lower than 0");

            try
            {
                var product = await _service.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery]string? searchTerm = null, [FromQuery] string? authorName = null)
        {
            var products = await _service.SearchProductsAsync(searchTerm, authorName);

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
            if (isbn == null || isbn == "")
                return BadRequest("isbn can not be null or empty");

            var product = await _service.GetProductByISBNAsync(isbn);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableProducts()
            => Ok(await _service.GetAvailableProductsAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _service.AddProductAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id) 
                return BadRequest();

            await _service.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
