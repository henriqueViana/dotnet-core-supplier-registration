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
    [Route("api/fornecedores")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public Task<IEnumerable<SupplierDTO>> GetAll()
        {
            return _supplierService.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierDTO>> GetById(Guid id)
        {
            var supplier = await _supplierService.GetById(id);

            if (supplier == null) return NotFound();

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> Create(SupplierDTO supplierDTO)
        {
            var result = await _supplierService.Create(supplierDTO);

            if (!result) return BadRequest();

            return Created("api/fornecedores", supplierDTO);
        }
    }
}