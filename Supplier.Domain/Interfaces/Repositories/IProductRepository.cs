using SupplierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        //Task<IEnumerable<Product>> GetProductsBySupplierId(Guid id);
        void GetProductsBySupplierId(Guid id);
    }
}
