using CustomerWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerController(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _customerDbContext.Customers;
        }

        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            var customer = await _customerDbContext.Customers.FindAsync(customerId);

            return customer;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customerDbContext.Customers.AddAsync(customer);
                    await _customerDbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState.Values);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            _customerDbContext.Customers.Update(customer);
            await _customerDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{customerId:int}")]
        public async Task<ActionResult> Delete(int customerId)
        {
            var customer = await _customerDbContext.Customers.FindAsync(customerId);
            _customerDbContext.Remove(customer);
            _customerDbContext.SaveChanges();
            return Ok();
        }
    }
}
