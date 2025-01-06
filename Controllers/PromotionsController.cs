using Ecommerce_API.DTO;
using Ecommerce_API.Services;
using Ecommerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionsRepo promotionsRepo;

        public PromotionsController(IPromotionsRepo promotionsRepo)
        {
            this.promotionsRepo = promotionsRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                var list = promotionsRepo.GetAll();
                return Ok(list);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var promotion = promotionsRepo.GetById(id);
                if (promotion != null)
                {
                    return Ok(promotion);
                }
                return NotFound("The Id is not found");
            }
            return BadRequest(ModelState);

        }
        [HttpGet("GetByName")]

        public IActionResult GetByName(string name)
        {
            if (ModelState.IsValid)
            {
                var promotion = promotionsRepo.GetByName(name);
                if (promotion != null)
                {
                    return Ok(promotion);
                }
                return NotFound("The Name is not found");
            }
            return BadRequest(ModelState);

        }
        [HttpPost]
        public IActionResult AddPromotion(PromotionsDto promotionDto)
        {
            if (ModelState.IsValid)
            {
                int row = promotionsRepo.Create(promotionDto);
                if (row > 0)
                {
                    return Ok("Added");
                }
                return BadRequest(ModelState);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Update(int id, PromotionsDto promotionsDto)
        {
            if (ModelState.IsValid)
            {
                var promotoin = promotionsRepo.update(id, promotionsDto);
                if (promotoin != null)
                {
                    return Ok(promotoin);
                }
                return NotFound("The Id Not fount");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var row = promotionsRepo.Delete(id);
                if (row > 0)
                {
                    return Ok("Deleted");
                }
                return NotFound("the Id Not found");
            }
            return BadRequest(ModelState);
        }
    }
}
