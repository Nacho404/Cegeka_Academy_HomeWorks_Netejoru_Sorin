using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CustomerController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return Ok(customers);
        }

        


        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new Customer
            {
                Name = model.Name,
                Email = model.Email
            };
            _dbContext.Customers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);

        }


        [HttpPut("update-customer-by-id/{customerId}")]
        public async Task<IActionResult> Put(int customerId, CustomerRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == customerId);

            if (customer != null)
            {
                customer.Name = model.Name;
                customer.Email = model.Email;

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return NotFound("Customer ID not found in 'Customers' table");
            }


            return Ok(customer);
        }



        [HttpDelete("delete-customer-by-id/{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == customerId);

            if(customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }else
            {
                return NotFound("Customer ID not found in 'Customers' table");
            }

            //return Delete(Request.GetDisplayUrl(), customer);

            return Ok(customer);

        }

    }
}
