using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Interfaces.Services;

namespace SupplierProject.Services.Controllers
{
    [Route("api/fornecedores")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
            var i = 0;
        }

        [HttpGet]
        public Task<IEnumerable<SupplierDTO>> GetAll()
        {
            return _supplierService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierDTO>> GetById(Guid id)
        {
            var supplier = await _supplierService.GetSupplierAndAddressAndProducts(id);

            if (supplier == null) return NotFound();
            
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> Create(SupplierDTO supplierDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _supplierService.Create(supplierDTO);

            if (!result) return BadRequest();

            return Created("api/fornecedores", supplierDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SupplierDTO>> Update(Guid id, SupplierDTO supplierDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var isExist = await _supplierService.IsExist(id);

            if (!isExist) return NotFound();

            var result = await _supplierService.Update(id, supplierDTO);

            if (!result) return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SupplierDTO>> Destroy(Guid id)
        {
            var supplier = await GetSuppier(id);

            if (supplier == null) return NotFound();

            var result = await _supplierService.Destroy(id);

            if (!result) return BadRequest();

            return Ok(supplier);
        }

        public async Task<SupplierDTO> GetSuppier(Guid id)
        {
            return await _supplierService.GetById(id);
        }
    }
}