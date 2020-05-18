using AutoMapper;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Interfaces.Repositories;
using SupplierProject.Domain.Interfaces.Services;
using SupplierProject.Domain.Models;
using SupplierProject.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Domain.Services
{
    public class SupplierService : Service, ISupplierService
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        //private readonly IAddressRepository _addressRepository;

        public SupplierService(
            ISupplierRepository supplierRepository,
            IMapper mapper
            )
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            //_addressRepository = addressRepository;
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
            var supplier = _mapper.Map<Supplier>(supplierDTO);

            if (!Validate(new SupplierValidation(), supplier)) return false;

            var result = await _supplierRepository.Create(supplier);

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
            var hasProduct = _supplierRepository.GetSupplierAndAddressAndProducts(id).Result.Products.Any();

            if (hasProduct) return false;
            /*
            var address = await _addressRepository.GetAddressBySupplierId(id);

            if (address != null)
            {
                await _addressRepository.Destroy(address.Id);
            }
            */

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

        public void Dispose()
        {
            _supplierRepository?.Dispose();
            // _addressRepository?.Dispose();
        }
    }
}
