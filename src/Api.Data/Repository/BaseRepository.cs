using System;
using Api.Data.Context;
using Api.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Interfaces.Repository;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MarketDbContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(MarketDbContext context)
        {
            this._context = context;
            this._dataSet = context.Set<T>();
        }

        public async Task<bool> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                    item.Id = Guid.NewGuid();

                item.CreatAt = DateTime.UtcNow;
                _dataSet.Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}