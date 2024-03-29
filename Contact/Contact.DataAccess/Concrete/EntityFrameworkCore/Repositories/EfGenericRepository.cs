﻿using Contact.DataAccess.Interfaces;
using Contact.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using var context = new ContactContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new ContactContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new ContactContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new ContactContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new ContactContext();
            return await context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new ContactContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using var context = new ContactContext();
            return await context.FindAsync<TEntity>(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var context = new ContactContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new ContactContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new ContactContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetByUUIdAsync(Guid id)
        {
            using var context = new ContactContext();
            return await context.FindAsync<TEntity>(id);
        }
    }
}
