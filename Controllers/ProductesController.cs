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
    public class ProductesController : ControllerBase
    {
        private readonly IProductesRepo productesRepo;

        public ProductesController(IProductesRepo productesRepo) 
        {
            this.productesRepo = productesRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                var list =  productesRepo.GetAll();
                return Ok(list);
            }
            return BadRequest(ModelState);       
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var prodecteDto= productesRepo.GetById(id);
                if (prodecteDto != null)
                {
                    return Ok(prodecteDto);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
                if (ModelState.IsValid)
                {
                    var prodecteDto = productesRepo.GetByName(name);
                    if (prodecteDto != null)
                    {
                        return Ok(prodecteDto);
                    }
                    return NotFound();
                }
                return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add(ProductesDto productesDto)
        {
            if (ModelState.IsValid)
            {
               int row=productesRepo.Create(productesDto);
                if (row > 0)
                {
                    return Ok("Added");
                }
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int id, ProductesDto productesDto)
        {
            if (ModelState.IsValid)
            {
                var prodecteDto=productesRepo.update(id, productesDto);
                if (prodecteDto != null)
                {
                    return Ok(prodecteDto);
                }
                return NotFound("The id not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                int row=productesRepo.Delete(id);
                if (row > 0)
                {
                    return Ok("Deleted");
                }
                return NotFound("The id not found");
            }
            return BadRequest(ModelState);
        }
    }
}
