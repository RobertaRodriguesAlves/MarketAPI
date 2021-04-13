using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Repository
{
    public interface IProviderRepository : IRepository<ProviderEntity>
    {
         Task<ProviderEntity> SelectByCnpj(string cnpj);
         Task<bool> DeleteByCnpj(string cnpj);
         Task<ProviderEntity> UpdateByCnpj(ProviderEntity provider);
    }
}