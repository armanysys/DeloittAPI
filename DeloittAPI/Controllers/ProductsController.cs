using System;
using DeloittAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DeloittAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/GetProducts
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // POST: api/products/SetProductCapacity/{productId}/{capacity}
        [HttpPost("SetProductCapacity/{productId}/{capacity}")]
        public async Task<IActionResult> SetProductCapacity(int productId, int capacity)
        {
            var result = await _productService.SetProductCapacityAsync(productId, capacity);
            if (result.Success)
                return Ok(result);
            else
                return NotFound(result);
        }

        // POST: api/products/ReceiveProduct/{productId}/{quantity}
        [HttpPost("ReceiveProduct/{productId}/{quantity}")]
        public async Task<IActionResult> ReceiveProduct(int productId, int quantity)
        {
            var result = await _productService.ReceiveProductAsync(productId, quantity);
            if (result.Success)
                return Ok(result);
            else
                return  NotFound(result);
        }

        // POST: api/products/DispatchProduct/{productId}/{quantity}
        [HttpPost("DispatchProduct/{productId}/{quantity}")]
        public async Task<IActionResult> DispatchProduct(int productId, int quantity)
        {
            var result = await _productService.DispatchProductAsync(productId, quantity);
            if (result.Success)
                return Ok(result);
            else
                return NotFound(result);
        }
    }


}

