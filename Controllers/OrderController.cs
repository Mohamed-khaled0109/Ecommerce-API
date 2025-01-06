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
    public class OrderController : ControllerBase
    {
        private readonly IOrdersRepo iOrdersRepo;

        // private readonly  IOrdersRepo iOrdersRepo;
        public OrderController(IOrdersRepo _IOrdersRepo)
        {
            iOrdersRepo = _IOrdersRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            if (ModelState.IsValid)
            {
                var orders = iOrdersRepo.GetAll();
                return Ok(orders);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var order=iOrdersRepo.GetById(id);
                return Ok(order);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public IActionResult Add(OrdersDto ordersdto)
        {

            if (ModelState.IsValid)
            { 
                var  order= iOrdersRepo.Create(ordersdto);
                return Ok(order);
            }
            else
            {
                return BadRequest(ModelState);
            }
        
        
        
        }
        [HttpPut]
        public IActionResult Update(int id,OrdersDto ordersdto) 
        { 
            if(ModelState.IsValid)
            {
                var oreders=iOrdersRepo.update(id,ordersdto);
                if(oreders != null)
                {
                    return Ok(oreders);
                }
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Deleet(int id)
        {
            if(ModelState.IsValid)
            {
                int  del=iOrdersRepo.Delete(id);
                if(del != 0)
                {
                    return Ok("deleted");
                }
                else
                {
                    return BadRequest(ModelState);
                }
               
            }
            return BadRequest(ModelState);

        }

    }
}
