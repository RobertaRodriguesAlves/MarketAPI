using System;
using Api.Data.Context;
using Api.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Interfaces.Repository;

namespace Api.Data.Repository
{
    public class ProviderRepository : BaseRepository<ProviderEntity>, IProviderRepository
    {
        private readonly DbSet<ProviderEntity> _dataSet;
        public ProviderRepository(MarketDbContext context) : base(context)
        {
            this._dataSet = context.Set<ProviderEntity>();
        }

        public async Task<bool> DeleteByCnpj(string cnpj)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(prov => prov.Cnpj.Equals(cnpj));
                if(result == null)
                    return false;
                
                _dataSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<ProviderEntity> SelectByCnpj(string cnpj)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(prov => prov.Cnpj.Equals(cnpj));
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<ProviderEntity> UpdateByCnpj(ProviderEntity provider)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(prov => prov.Cnpj.Equals(provider.Cnpj));
                if(result == null)
                    return null;
                
                provider.Id = result.Id;
                provider.UpdateAt = DateTime.UtcNow;
                provider.CreatAt = result.CreatAt;
                _context.Entry(result).CurrentValues.SetValues(provider);
                await _context.SaveChangesAsync();
                return provider;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}