using AutoMapper;
using Api.Domain.Entities;
using Api.Domain.DTO.Client;
using System.Threading.Tasks;
using Api.Domain.Models.Client;
using System.Collections.Generic;
using Api.Domain.Interfaces.Client;
using Api.Domain.Interfaces.Repository;

namespace Api.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this._clientRepository = clientRepository;
            this._mapper = mapper;
        }
        public async Task<bool> Delete(string document)
        {
            return await _clientRepository.DeleteByDocument(document);
        }

        public async Task<ClientDTOResult> Get(string document)
        {
            var result = await _clientRepository.SelectByDocument(document);
            return _mapper.Map<ClientDTOResult>(result);
        }

        public async Task<IEnumerable<ClientDTOResult>> GetAll()
        {
            var result = await _clientRepository.SelectAsync();
            return _mapper.Map<IEnumerable<ClientDTOResult>>(result);
        }

        public async Task<bool> Post(ClientDTO client)
        {
            var model = _mapper.Map<ClientModel>(client);
            var entity = _mapper.Map<ClientEntity>(model);
            return await _clientRepository.InsertAsync(entity);
        }

        public async Task<ClientDTOResult> Put(ClientDTO client)
        {
            var model = _mapper.Map<ClientModel>(client);
            var entity = _mapper.Map<ClientEntity>(model);
            var result =  await _clientRepository.UpdateByDocument(entity);
            return _mapper.Map<ClientDTOResult>(result);
        }

    }
}