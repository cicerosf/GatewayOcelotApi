using CustomerMicroservice.Data;
using CustomerMicroservice.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            if (customers == null)
            { 
                return NotFound();
            }

            return Ok(customers);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return Ok(customer);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Customer customer, int id)
        {
            if (customer.Id != id)
            { 
                return BadRequest();
            }

            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
