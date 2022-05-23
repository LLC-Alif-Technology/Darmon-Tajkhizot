using Contracts.Repositories;
using Entities.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DataContext Context;
        public RepositoryBase(DataContext context)
        {
            Context = context;
        }

        public async Task<bool> CheckExistingByConditionAsync(Expression<Func<T, bool>> expression) => await Context.Set<T>().AnyAsync(expression);

        public async Task CreateAsync(T entity) => await Context.Set<T>().AddAsync(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? Context.Set<T>().AsNoTracking() : Context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ? Context.Set<T>().Where(expression).AsNoTracking() : Context.Set<T>().Where(expression);
        public void Update(T entity) => Context.Set<T>().Update(entity);
    }
}
