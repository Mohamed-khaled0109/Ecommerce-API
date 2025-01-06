using Ecommerce_API.DTO;
using Ecommerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingRepo shippingRepo;

        public ShippingController(IShippingRepo shippingRepo)
        {
            this.shippingRepo = shippingRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(shippingRepo.GetAll());
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var shipping = shippingRepo.GetById(id);
                if (shipping != null)
                {
                    return Ok(shipping);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult AddShipping(ShippingDto shippingDto)
        {
            if (ModelState.IsValid)
            {
                int row = shippingRepo.Create(shippingDto);
                if (row > 0)
                {
                    return Ok(shippingDto);
                }
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int id, ShippingDto shippingDto)
        {
            if (ModelState.IsValid)
            {
                var sipping = shippingRepo.update(id, shippingDto);
                if (sipping != null)
                {
                    return Ok(sipping);
                }
                return NotFound("The Id Not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                int row = shippingRepo.Delete(id);
                if (row > 0)
                {
                    return Ok("deleted");
                }
                return NotFound("The Id not found");
            }
            return BadRequest(ModelState);
        }
    }
}
