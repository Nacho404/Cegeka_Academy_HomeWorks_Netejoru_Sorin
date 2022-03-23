using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;

namespace CarDealership.Controllers
{
    //[EnableCors("AllowSpecific")]
    [ApiController]
    [Route("[controller]")]
    public class CarOfferController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CarOfferController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var offers = await _dbContext.CarOffers.ToListAsync();
            return Ok(offers);
        }

        [HttpGet("select-carOffer-by-id/{carOfferId}")]

        public async Task<IActionResult> GetById(int carOfferId)
        {
            var offer = await _dbContext.CarOffers.FirstOrDefaultAsync(x => x.Id == carOfferId);

            if(offer != null)
            {
                return Ok(offer);
            } else
            {
                return NotFound("CarOffer ID not found in 'CarOffers' table");

            }
        }

        [HttpPost("create-carOffer")]
        public async Task<IActionResult> Post([FromBody] CarOfferRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new CarOffer
            {
                Make = model.Make,
                Model = model.Model,
                AvailableStock = model.AvailableStock,
                UnitPrice = model.UnitPrice,
                DiscountPercentage = model.DiscountPercentage,
                Image = model.Image
            };

            _dbContext.CarOffers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }


        [HttpPut("update-carOffer-by-id/{carOfferId}")]
        public async Task<IActionResult> Put(int carOfferId, CarOfferRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offer = _dbContext.CarOffers.FirstOrDefault(x => x.Id == carOfferId);

            if (offer != null)
            {
                offer.Make = model.Make;
                offer.Model = model.Model;
                offer.AvailableStock = model.AvailableStock;
                offer.UnitPrice = model.UnitPrice;
                offer.DiscountPercentage = model.DiscountPercentage;
                offer.Image = model.Image;


                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return NotFound("CarOffer ID not found in 'CarOffers' table");
            }


            return Ok(offer);
        }



        [HttpDelete("delete-carOffer-by-id/{carOfferId}")]
        public async Task<IActionResult> Delete(int carOfferId)
        {
            var offer = _dbContext.CarOffers.FirstOrDefault(x => x.Id == carOfferId);

            if (offer != null)
            {
                _dbContext.CarOffers.Remove(offer);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return NotFound("CarOffer ID not found in 'CarOffers' table");
            }

            return Ok(offer);

        }
    }
}