using System.Threading.Tasks;
using Api.Domain.DTO.Provider;
using System.Collections.Generic;

namespace Api.Domain.Interfaces.Provider
{
    public interface IProviderService
    {
         Task<ProviderDTOResult> Get(string cnpj);
         Task<IEnumerable<ProviderDTOResult>> GetAll();
         Task<bool> Post(ProviderDTO provider);
         Task<ProviderDTOResult> Put(ProviderDTO provider);
         Task<bool> Delete(string cnpj);
    }
}