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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SupplierDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsBySupplierId(Guid id)
        {
            return await GetByLambdaExpression(c => c.SupplierId == id);
        }

        public async Task<Product> GetProductAndSupplier(Guid id)
        {
            return await _context.Products.AsNoTracking()
                .Include(c => c.Supplier)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
