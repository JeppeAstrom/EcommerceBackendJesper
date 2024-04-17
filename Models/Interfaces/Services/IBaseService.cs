﻿using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EcommerceBackend.Models.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {

        public Task<bool> ExistsAsync(Guid id);
        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        public Task AddRangedAsync(ICollection<TEntity> entities);
        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<TEntity> UpdateAsync(TEntity entity);

        public Task<IActionResult> GetAllAsync();
        public Task<IEnumerable<TEntity>> GetAllIEnurableAsync();
    }
}
