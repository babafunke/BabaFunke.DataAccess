using Babafunke.DataAccessDemo.Models;
using BabaFunke.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Babafunke.DataAccessDemo.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productService;

        public ProductController(IRepository<Product> productService)
        {
            _productService = productService;
        }

        [HttpGet("product")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllItems();
            return Ok(products);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetItemById(id);

            if (product == null)
            {
                return NotFound($"Product with Id {id} not found!");
            }

            return Ok(product);
        }

        [HttpPost("product")]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (await _productService.GetItemById(product.Id) != null)
            {
                return BadRequest($"A product with Id {product.Id} already consists!");
            }

            var response = await _productService.CreateItem(product);
            return Ok(new {Message = "Successfully added!", Product = response});
        }

        [HttpPut("product/{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Ensure the Url Id and Json Body Id are the same!");
            }

            var response = await _productService.EditItem(product);

            if (response == null)
            {
                return NotFound($"The product with Id {id} does not exist!");
            }

            return Ok(response);
        }

        [HttpPatch("product/{id}")]
        public async Task<IActionResult> PatchProduct(int id)
        {
            var response = await _productService.ArchiveItem(id);

            if (!response)
            {
                return NotFound("The product to archive does not exist!");
            }

            return NoContent();
        }

        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.DeleteItem(id);

            if (!response)
            {
                return NotFound(false);
            }

            return NoContent();
        }
    }
}
