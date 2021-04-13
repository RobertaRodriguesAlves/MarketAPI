using Api.Domain.DTO.Client;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Api.Domain.Interfaces.Client
{
    public interface IClientService
    {
        Task<ClientDTOResult> Get(string document);
        Task<IEnumerable<ClientDTOResult>> GetAll();
        Task<bool> Post(ClientDTO client);
        Task<ClientDTOResult> Put(ClientDTO client);
        Task<bool> Delete(string document);
    }
}