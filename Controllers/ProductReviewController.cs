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
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductReviewRepo productReview;

        public ProductReviewController(IProductReviewRepo productReview)
        {
            this.productReview = productReview;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                var list = productReview.GetAll();
                return Ok(list);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var product = productReview.GetById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound("The Id Not found");
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add(ProductReviewDto productReviewDto)
        {
            if (ModelState.IsValid)
            {
                int row = productReview.Create(productReviewDto);
                if (row > 0)
                {
                    return Ok("Added");
                }
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Update(int id, ProductReviewDto productReviewDto)
        {
            if (ModelState.IsValid)
            {
                var review = productReview.update(id, productReviewDto);
                if (review != null)
                {
                    return Ok(review);
                }
                return NotFound("the Id not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                int row = productReview.Delete(id);
                if (row > 0)
                {
                    return Ok("Deleted");
                }
                return BadRequest("the Id not found");

            }
            return BadRequest(ModelState);
        }
    }
}
