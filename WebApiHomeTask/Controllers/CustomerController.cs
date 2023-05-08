using Microsoft.AspNetCore.Mvc;
using WebApiHomeTask.DataToObjects;
using WebApiHomeTask.Entities;
using WebApiHomeTask.Services.Abstract;

namespace WebApiHomeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            var customers = _customerService.GetAllElements();
            var dataToReturn = customers.Select(c =>
            {
                return new CustomerDto { 
                
                    Id = c.Id,
                    Name = c.Name,
                    Surname= c.Surname,
                
                };
            });
            return dataToReturn;
        }


        [HttpGet("id")]
        public CustomerDto Get(int id) {

            var customer = _customerService.GetElement(id);
            var dataToReturn = new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname= customer.Surname
            };
            return dataToReturn;
        }


        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customer)
        {
            try
            {
                var obj = new Customer
                {
                    Name= customer.Name,
                    Surname= customer.Surname
                };
                _customerService.AddElement(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDto customer)
        {
            try
            {
                var item = _customerService.GetElement(id);
                item.Name= customer.Name;
                item.Surname= customer.Surname;
                _customerService.UpdateElement(item);
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
                _customerService.DeleteElement(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
