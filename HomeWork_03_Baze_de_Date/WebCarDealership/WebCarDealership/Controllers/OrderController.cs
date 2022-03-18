using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public OrderController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("select-order-by-id/{orderId}")]
        public async Task<IActionResult> Get(int orderId)
        {
            var offer = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId);

            if(offer != null)
            {
                return Ok(offer);
            } else
            {
                return NotFound("Order Id not found in 'Orders' table");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var offer = await _dbContext.CarOffers.FirstOrDefaultAsync(offer => offer.Id == model.CarOfferId);
            if (offer == null)
            {
                return NotFound("car offer not found");
            }

            if (offer.AvailableStock <= model.Quantity)
            {
                return BadRequest("Not enough cars of this model are available in stock!");
            }

            offer.AvailableStock -= model.Quantity;

            var dbOrder = new Order()
            {
                CarOfferId = model.CarOfferId,
                CustomerId = model.CustomerId,
                Date = DateTime.UtcNow,
                Quantity = model.Quantity,
                OrderAmount = model.Quantity * offer.UnitPrice
            };
            _dbContext.Orders.Add(dbOrder);

            await _dbContext.SaveChangesAsync();

            //int numberOfRecordsAffected = 
            //if (numberOfRecordsAffected == 0)
            //{
            //}

            return Ok(dbOrder);
        }
    }
}
