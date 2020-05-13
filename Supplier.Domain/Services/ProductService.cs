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
    public class ProductService : Service, IProductService 
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetAll());
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetById(id));
        }

        public async Task<bool> Create(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            var result = await _productRepository.Create(product);

            if (result == 0) return false;
            
            return true;
        }

        public async Task<bool> Update(Guid id, ProductDTO productDTO)
        {
            if (productDTO.Id != id) return false;

            var product = _mapper.Map<Product>(productDTO);
            var result = await _productRepository.Update(product);

            if (result == 0) return false;

            return true;
        }

        public async Task<bool> Destroy(Guid id)
        {
            var result = await _productRepository.Destroy(id);

            if (result == 0) return false;

            return true;
        }
    }
}
