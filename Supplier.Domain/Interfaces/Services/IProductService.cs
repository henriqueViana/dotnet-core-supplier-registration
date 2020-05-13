using SupplierProject.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetById(Guid id);
        Task<bool> Create(ProductDTO product);
        Task<bool> Update(Guid id, ProductDTO product);
        Task<bool> Destroy(Guid id);

    }
}
