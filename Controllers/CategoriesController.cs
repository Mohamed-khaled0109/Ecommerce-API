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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepo categoriesRepo;

        public CategoriesController(ICategoriesRepo categoriesRepo)
        {
            this.categoriesRepo = categoriesRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(categoriesRepo.GetAll());
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var category = categoriesRepo.GetById(id);
                if (category != null)
                {
                    return Ok(category);
                }
                return NotFound("The Id not found");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            if (ModelState.IsValid)
            {
                var category = categoriesRepo.GetByName(name);
                if (category != null)
                {
                    return Ok(category);
                }
                return NotFound("The Id not found");
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult Add(CategoriesDto categoriesDto)
        {
            if (ModelState.IsValid)
            {
               int row=categoriesRepo.Create(categoriesDto);
                if (row > 0)
                {
                    return Ok("Added");
                }
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int id, CategoriesDto categoriesDto)
        {
            if (ModelState.IsValid)
            {
                var catrgory=categoriesRepo.update(id, categoriesDto);
                if (catrgory != null)
                {
                    return Ok(catrgory);
                }
                return NotFound("The Id not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                int row=categoriesRepo.Delete(id);
                if (row > 0)
                {
                    return Ok("Deleted");
                }
                return NotFound("The Id not found");
            }
            return BadRequest(ModelState);
        }
    }
}
