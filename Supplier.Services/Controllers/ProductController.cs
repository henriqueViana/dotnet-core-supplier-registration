using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            if (!ModelState.IsValid) return BadRequest();

            var imgName = CustomFileName(product.Image);

            if (!UploadFile(product.ImageUpload, imgName))
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Falha ao carregar a imagem"
                });
            }

            product.Image = imgName;

            var result = await _productService.Create(product);

            if (!result) return BadRequest();

            return Created("api/produtos", product);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProductDTO>> Update(Guid id, ProductDTO product)
        {
            if (!ModelState.IsValid) return BadRequest();

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

        private bool UploadFile(string file, string fileName)
        {
            if (string.IsNullOrEmpty(file))
            {
                ModelState.AddModelError(string.Empty, "A imagem do produto é obrigatória");
                return false;
            }

            var fileDataByteArray = Convert.FromBase64String(file);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgs", fileName);

            if (System.IO.File.Exists(filePath))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com o mesmo nome");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, fileDataByteArray);

            return true;
        }

        private string CustomFileName(string fileName)
        {
            return Guid.NewGuid() + "_" + fileName;
        }
    }
}