using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Repository
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
         Task<bool> DeleteByDocument(string document);
         Task<ClientEntity> SelectByDocument(string document);
         Task<ClientEntity> UpdateByDocument(ClientEntity client);
    }
}