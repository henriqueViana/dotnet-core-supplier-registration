using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Interfaces.Services;

namespace SupplierProject.Services.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public Task<IEnumerable<ProductDTO>>GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductDTO>> GetById(Guid id)
        {
            var product = await _productService.GetById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create(ProductDTO product)
        {
            var result = await _productService.Create(product);

            if (!result) return BadRequest();

            return Created("api/produtos", product);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductDTO>> Update(Guid id, ProductDTO product)
        {
            var result = await _productService.Update(id, product);

            if (!result) return BadRequest();

            return Ok(product);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductDTO>> Destroy(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null) return NotFound();

            bool result = await _productService.Destroy(id);

            if (!result) return BadRequest();

            return Ok(product);
        }

        private async Task<ProductDTO> GetProduct(Guid id)
        {
            return await _productService.GetById(id);
        }
    }
}