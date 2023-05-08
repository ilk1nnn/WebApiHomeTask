using Microsoft.AspNetCore.Mvc;
using WebApiHomeTask.DataToObjects;
using WebApiHomeTask.Entities;
using WebApiHomeTask.Services.Abstract;

namespace WebApiHomeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            var products = _productService.GetAllElements();
            var dataToReturn = products.Select(p =>
            {
                return new ProductDto
                {
                    Id = p.Id,
                    ProductName= p.ProductName,
                    ProductPrice= p.ProductPrice,
                    ProductDiscount= p.ProductDiscount
                };
            });
            return dataToReturn;
        }


        [HttpGet("{id}")]
        public ProductDto GetById(int id)
        {
            var product = _productService.GetElement(id);
            var dataToReturn = new ProductDto
            {
                Id= product.Id,
                ProductName= product.ProductName,
                ProductPrice= product.ProductPrice,
                ProductDiscount= product.ProductDiscount
            };
            return dataToReturn;
        }

        [HttpGet("HigherDiscount")]
        public IEnumerable<ProductDto> GetHigherDiscount()
        {
            return _productService.GetHigherDiscount();
        }


        [HttpPost]
        public IActionResult Post([FromBody] ProductDto product) {

            try
            {
                var obj = new Product { Id= product.Id, ProductName=product.ProductName
                ,ProductDiscount= product.ProductDiscount, ProductPrice= product.ProductPrice
                };
                _productService.AddElement(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto value)
        {
            try
            {
                var item = _productService.GetElement(id);
                item.ProductName = value.ProductName;
                item.ProductPrice = value.ProductPrice;
                item.ProductDiscount = value.ProductDiscount;
                _productService.UpdateElement(item);
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
                _productService.DeleteElement(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
