using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SupplierProject.Domain.Interfaces.Repositories;
using SupplierProject.Domain.Models;
using SupplierProject.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupplierProject.Infra.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly SupplierDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(SupplierDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetByLambdaExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public virtual async Task<int> Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> Destroy(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
