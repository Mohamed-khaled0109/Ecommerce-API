using Ecommerce_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_API.Services.Interfaces;
using Ecommerce_API.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepo cartRepo;

        public ShoppingCartController(IShoppingCartRepo cartRepo)
        {
            this.cartRepo = cartRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {

                return Ok(cartRepo.GetAll());
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetById/{id:int}")]

        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var shoppingCart = cartRepo.GetById(id);
                if (shoppingCart != null)
                {
                    return Ok(shoppingCart);
                }
                return NotFound("the Id not found");//هترجه 404 Not found
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult AddShoppingCart(ShoppingCartDto shoppingCartDto)
        {
            if (ModelState.IsValid)
            {
                cartRepo.Create(shoppingCartDto);
                return Ok("Added");
            }
            return BadRequest(ModelState);

        }


        [HttpPut]
        public IActionResult Update(int id, ShoppingCartDto shoppingCart)
        {
            if (ModelState.IsValid)
            {
                var cart = cartRepo.update(id, shoppingCart);
                if (cart != null)
                {
                    return Ok(cart);
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
                int row = cartRepo.Delete(id);
                if (row > 0)
                {
                    return Ok("Deleted");
                }
                return BadRequest("The Id Not found");
            }
            return BadRequest(ModelState);
        }
    }
}
