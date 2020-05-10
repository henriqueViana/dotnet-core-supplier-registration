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
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Destroy(Guid id);
    }
}
