using Ecommerce_API.DTO;
using Ecommerce_API.Model;
using Ecommerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithPormotionsController : ControllerBase
    {
        private readonly IProductWithPormotionsRepo repo;

        public ProductWithPormotionsController(IProductWithPormotionsRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(repo.GetAll());
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetById/{id:int}")]

        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var product = repo.GetById(id);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound("The Id not found");
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add(ProductWithPormotionsDto pormotionsDto)
        {
            if (!ModelState.IsValid)
            {
                int row = repo.Create(pormotionsDto);
                if (row > 0)
                {
                    return Ok("Added");
                }
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int id, ProductWithPormotionsDto pormotionsDto)
        {
            if (ModelState.IsValid)
            {
                var poromotion = repo.update(id, pormotionsDto);
                if (poromotion != null)
                {
                    return Ok(poromotion);
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
                int row = repo.Delete(id);
                if (row > 0)
                {
                    return Ok("Deleted");
                }
                return NotFound("the Id not found");
            }
            return BadRequest(ModelState);
        }
    }
}
