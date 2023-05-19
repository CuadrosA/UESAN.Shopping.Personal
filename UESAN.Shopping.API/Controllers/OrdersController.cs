using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;

namespace UESAN.Shopping.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _ordersService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orders = await _ordersService.GetById(id);
            if (orders == null) 
                return NotFound();
                
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(OrdersInsertDTO orders)
        {
            var result = await _ordersService.Insert(orders);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrdersUpdateDTO orders)
        {
            if (id != orders.Id)
                return NotFound();

            var result = await _ordersService.Update(orders);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
