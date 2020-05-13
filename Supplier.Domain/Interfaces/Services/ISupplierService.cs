using SupplierProject.Application.DTO;
using SupplierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Domain.Interfaces.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDTO>> GetAll();
        Task<SupplierDTO> GetById(Guid id);
        Task<bool> Create(SupplierDTO supplier);
        Task<bool> Update(Guid id, SupplierDTO supplier);
        Task<bool> Destroy(Guid id);
        Task<SupplierDTO> GetSupplierAndAddress(Guid id);
        Task<SupplierDTO> GetSupplierAndAddressAndProducts(Guid id);
    }
}
