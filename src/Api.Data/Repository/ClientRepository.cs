using System;
using Api.Data.Context;
using Api.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Interfaces.Repository;

namespace Api.Data.Repository
{
    public class ClientRepository : BaseRepository<ClientEntity>, IClientRepository
    {
        private readonly DbSet<ClientEntity> _dataSet;
        public ClientRepository(MarketDbContext context) : base(context)
        {
            this._dataSet = context.Set<ClientEntity>();
        }
        public async Task<bool> DeleteByDocument(string document)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(client => client.Document.Trim().Equals(document));
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

        public async Task<ClientEntity> SelectByDocument(string document)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(client => client.Document.Trim().Equals(document));
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<ClientEntity> UpdateByDocument(ClientEntity client)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(res => res.Document.Trim().Equals(client.Document));
                if(result == null)
                    return null;
                
                client.Id = result.Id;
                client.UpdateAt = DateTime.UtcNow;
                client.CreatAt = result.CreatAt;
                _context.Entry(result).CurrentValues.SetValues(client);
                await _context.SaveChangesAsync();
                return client;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}