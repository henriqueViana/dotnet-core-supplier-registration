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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository 
    {
        public SupplierRepository(SupplierDbContext context) : base(context) { }

        public async Task<Supplier> GetSupplierAndAddress(Guid id)
        {
            return await _context.Suppliers.AsNoTracking()
                .Include(column => column.Address)
                .FirstOrDefaultAsync(column => column.Id == id);
        }

    }
}
