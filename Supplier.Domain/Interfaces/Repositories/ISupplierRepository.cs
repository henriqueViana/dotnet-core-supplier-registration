using SupplierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Domain.Interfaces.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierAndAddress(Guid Id);
        Task<Supplier> GetSupplierAndAddressAndProducts(Guid Id);
    }
}
