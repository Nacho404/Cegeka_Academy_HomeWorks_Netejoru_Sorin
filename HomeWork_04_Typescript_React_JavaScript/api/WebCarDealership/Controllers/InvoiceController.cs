using CarDealership.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public InvoiceController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost("create-invoice")]
        public async Task<IActionResult> Post(InvoiceRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == model.CustomerId);
            if (customer == null)
            {
                return NotFound("customer not found");
            }


          
            var dbModel = new Invoice
            {
                CustomerId = model.CustomerId,
                InvoiceNumber = model.InvoiceNumber,
                InvoiceDate = DateTime.UtcNow,
                Amount = 0
            };

            _dbContext.Invoices.Add(dbModel);
            await _dbContext.SaveChangesAsync();

            return Ok(dbModel);


        }

    }
}
