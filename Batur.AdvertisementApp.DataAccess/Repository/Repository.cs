using Batur.AdvertisementApp.Common.Enums;
using Batur.AdvertisementApp.DataAccess.Context;
using Batur.AdvertisementApp.DataAccess.Interfaces;
using Batur.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntiy
    {
        private readonly AdvertisementContext _context;

        public Repository(AdvertisementContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().OrderBy(selector).ToListAsync() : await _context.Set<T>().OrderByDescending(selector).AsNoTracking().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).OrderBy(selector).AsNoTracking().ToListAsync() : await _context.Set<T>().Where(filter).OrderByDescending(selector).AsNoTracking().ToListAsync();
        }

        public async Task<T> Find(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) : await _context.Set<T>().SingleOrDefaultAsync(filter);
        }
        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T enity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(enity);
        }

    }
}
