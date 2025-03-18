using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBookHaven2.Interface;
using TheBookHaven2.Models;

namespace TheBookHaven2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllCustomersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var customer = await _service.GetCustomerByEmailAsync(email);
            return customer == null ? NotFound() : Ok(customer);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _service.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            if (id != customer.Id) return BadRequest();
            await _service.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
