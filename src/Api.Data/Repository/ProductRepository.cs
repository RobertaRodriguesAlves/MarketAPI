using System;
using Api.Data.Context;
using Api.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Interfaces.Repository;

namespace Api.Data.Repository
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        private readonly DbSet<ProductEntity> _dataSet;
        public ProductRepository(MarketDbContext context) : base(context)
        {
            this._dataSet = context.Set<ProductEntity>();
        }
        public async Task<bool> DeleteByName(string name)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(product => product.Name.Trim().Equals(name.Trim()));
                if (result == null)
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

        public async Task<bool> Insert(ProductEntity product)
        {
            try
            {
                var provider = await _context.Providers.SingleOrDefaultAsync(prov => prov.Cnpj.Equals(product.Provider.Cnpj));

                if(product.Id == Guid.Empty)
                    product.Id = Guid.NewGuid();
                
                product.CreatAt = DateTime.UtcNow;
                product.Provider = provider;
                _dataSet.Add(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<ProductEntity> SelectByName(string name)
        {
            try
            {
                return await _dataSet.Include(prod => prod.Provider).SingleOrDefaultAsync(product => product.Name.Trim().Equals(name.Trim()));
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
        
        public async Task<ProductEntity> Update(ProductEntity product)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(prod => prod.Name.Trim().Equals(product.Name.Trim()));
                if (result == null)
                    return null;

                product.Id = result.Id;
                product.UpdateAt = DateTime.UtcNow;
                product.CreatAt = result.CreatAt;
                _context.Entry(result).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}