using AutoMapper;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Interfaces.Repositories;
using SupplierProject.Domain.Interfaces.Services;
using SupplierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Domain.Services
{
    public class AddressService : Service, IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public AddressService(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<bool> Update(Guid id, AddressDTO addressDTO)
        {
            if (id != addressDTO.Id) return false;

            var result = await _addressRepository.Update(_mapper.Map<Address>(addressDTO));

            if (result == 0) return false;

            return true;
        }

        public async Task<bool> Destroy(Guid id)
        {
            var result = await _addressRepository.Destroy(id);

            if (result == 0) return false;

            return true;
        }

        public async Task<bool> IsExist(Guid id)
        {
            var address = await _addressRepository.GetById(id);

            if (address == null) return false;

            return true;
        }

        public void Dispose()
        {
            _addressRepository?.Dispose();
        }
    }
}
