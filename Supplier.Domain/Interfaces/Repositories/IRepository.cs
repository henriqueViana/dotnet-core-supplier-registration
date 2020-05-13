using SupplierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(Guid Id);
        Task<int> Create(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Destroy(Guid id);
    }
}
