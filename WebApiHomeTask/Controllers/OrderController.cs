using Microsoft.AspNetCore.Mvc;
using WebApiHomeTask.DataToObjects;
using WebApiHomeTask.Entities;
using WebApiHomeTask.Services.Abstract;
using WebApiHomeTask.Services.Concrete;

namespace WebApiHomeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<OrderDto> Get()
        {
            var orders = _orderService.GetAllElements();
            var dataToReturn = orders.Select(o =>
            {
                return new OrderDto
                {

                    Id = o.Id,
                    OrderDate= o.OrderDate,
                    CustomerId= o.CustomerId,
                    ProductId= o.ProductId,

                };
            });
            return dataToReturn;
        }

        [HttpGet("id")]
        public OrderDto Get(int id)
        {

            var order = _orderService.GetElement(id);
            var dataToReturn = new OrderDto
            {
                Id = order.Id,
                OrderDate= order.OrderDate,
                CustomerId= order.CustomerId,
                ProductId= order.ProductId,
            };
            return dataToReturn;
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderDto order)
        {
            try
            {
                var obj = new Order
                {
                    OrderDate= order.OrderDate,
                    CustomerId= order.CustomerId,
                    ProductId= order.ProductId,
                };
                _orderService.AddElement(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDto order)
        {
            try
            {
                var item = _orderService.GetElement(id);
                item.OrderDate = order.OrderDate;
                item.CustomerId = order.CustomerId;
                item.ProductId = order.ProductId;
                _orderService.UpdateElement(item);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _orderService.DeleteElement(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
