using Microsoft.EntityFrameworkCore;
using SupplierProject.Domain.Interfaces.Repositories;
using SupplierProject.Domain.Models;
using SupplierProject.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Infra.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(SupplierDbContext context) : base(context)
        {

        }

        public async Task<Address> GetAddressBySupplierId(Guid id)
        {
            return await _context.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(c => c.SupplierId == id);
        }
    }
}
