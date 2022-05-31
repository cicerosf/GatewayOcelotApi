using ProductMicroservice.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Data;

namespace ProductMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _dbContext.Products.ToListAsync();
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product customer)
        {
            _dbContext.Products.Add(customer);
            await _dbContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Product customer, int id)
        {
            if (customer.Id != id)
            {
                return BadRequest();
            }

            _dbContext.Products.Update(customer);
            await _dbContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
