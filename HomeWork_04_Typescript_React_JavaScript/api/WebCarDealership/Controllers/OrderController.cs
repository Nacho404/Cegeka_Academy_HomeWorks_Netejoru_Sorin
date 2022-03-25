using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        [HttpGet("select-all-orders")]
        public async Task<IActionResult> Get()
        {
            var orders = await _dbContext.Orders.ToListAsync();

            return Ok(orders);
        }

        [HttpGet("select-order-by-id/{orderId}")]
        public async Task<IActionResult> GetById(int orderId)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId);

            if(order != null)
            {
                return Ok(order);
            } else
            {
                return NotFound("Order Id not found in 'Orders' table");
            }
        }

        [HttpGet("select-all-orders-by-customerId/{customerId}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            var queryOrders = await _dbContext.Orders
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
            if(queryOrders.Count == 0)
            {
                return NotFound("Customer ID not found in 'Orders' table");
            }

            return Ok(queryOrders);
        }

        [HttpPost("create-order")]
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

            return Ok(dbOrder);
        }
    }
}
