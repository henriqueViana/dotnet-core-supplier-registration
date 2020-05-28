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
    [Route("api/fornecedor/endereco")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AddressDTO>> Update(Guid id, AddressDTO addressDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var address = await _addressService.IsExist(id);

            if (!address) return NotFound();

            var result = await _addressService.Update(id, addressDTO);

            if (!result) return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AddressDTO>> Destroy(Guid id)
        {
            return Ok();
        }
    }
}