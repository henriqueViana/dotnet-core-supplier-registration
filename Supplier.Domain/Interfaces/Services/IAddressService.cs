using SupplierProject.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        Task<bool> Update(Guid id, AddressDTO addressDTO);
        Task<bool> Destroy(Guid id);
        Task<bool> IsExist(Guid id);
    }
}
