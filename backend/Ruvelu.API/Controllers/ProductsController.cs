using Microsoft.AspNetCore.Mvc;
using Ruvelu.Core.Entities;
using Ruvelu.Core.Interfaces;

namespace Ruvelu.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    
    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult>GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create (Product product)
        {
            await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new {id = product.Id},product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Ürün Bulunamadı." });
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>  Update(int id, Product product) 
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if(existingProduct==null)
            {
                return NotFound(new {message="Ürün Bulunamadı."});
            }
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;
        existingProduct.ImageUrl = product.ImageUrl;
        
        await _productRepository.UpdateAsync(existingProduct);

        return NoContent();
            
        }
}

}

