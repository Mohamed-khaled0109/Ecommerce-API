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
    public class OrderDeetailsController : ControllerBase
    {
        private readonly IOrderDeetailsRepo deetailsRepo;

        public OrderDeetailsController(IOrderDeetailsRepo deetailsRepo)
        {
            this.deetailsRepo = deetailsRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(deetailsRepo.GetAll());
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var order=deetailsRepo.GetById(id);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound("The Id not found");
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add(OrderDeetailsDto orderDeetailsDto)
        {
            if (ModelState.IsValid)
            {
                int row=deetailsRepo.Create(orderDeetailsDto);
                if (row > 0)
                {
                    return Ok("Added");
                }
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int Id, OrderDeetailsDto orderDeetailsDto)
        {
            if (ModelState.IsValid)
            {
                var order=deetailsRepo.update(Id, orderDeetailsDto);
                if(order != null)
                {
                    return Ok(order);
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
               int row= deetailsRepo.Delete(id);
                if (row > 0)
                {
                    return Ok("Deleted");
                }
                return NotFound("The Id Not found");
            }
            return BadRequest(ModelState);
        }
    }
}
