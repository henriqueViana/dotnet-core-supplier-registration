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

        public void GetProductsBySupplierId(Guid id)
        {

        }
    }
}
