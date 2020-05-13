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
    public class SupplierService : ISupplierService
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<SupplierDTO>>(await _supplierRepository.GetAll());
        }

        public async Task<SupplierDTO> GetById(Guid Id)
        {
            return _mapper.Map<SupplierDTO>(await _supplierRepository.GetById(Id));
        }

        public async Task<bool> Create(SupplierDTO supplierDTO)
        {
            // supplier validation
            var result = await _supplierRepository.Create(_mapper.Map<Supplier>(supplierDTO));

            if (result == 0) return false;

            return true;
        }

        public async Task<bool> Update(Guid id, SupplierDTO supplierDTO)
        {
            if (supplierDTO.Id != id) return false;

            await _supplierRepository.Update(_mapper.Map<Supplier>(supplierDTO));

            return true;
        }

        public async Task<bool> Destroy(Guid id)
        {
            var result = await _supplierRepository.Destroy(id);

            if (result == 0) return false;

            return true;
        }

        public async Task<SupplierDTO> GetSupplierAndAddress(Guid id)
        {
            return _mapper.Map<SupplierDTO>(await _supplierRepository.GetSupplierAndAddress(id));
        }

        public async Task<SupplierDTO> GetSupplierAndAddressAndProducts(Guid id)
        {
            return _mapper.Map<SupplierDTO>(await _supplierRepository.GetSupplierAndAddressAndProducts(id));
        }
    }
}
