using AutoMapper;
using Api.Domain.Entities;
using System.Threading.Tasks;
using Api.Domain.DTO.Provider;
using System.Collections.Generic;
using Api.Domain.Models.Provider;
using Api.Domain.Interfaces.Provider;
using Api.Domain.Interfaces.Repository;

namespace Api.Service.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _repository;
        private readonly IMapper _mapper; 
        public ProviderService(IProviderRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<bool> Delete(string cnpj)
        {
            return await _repository.DeleteByCnpj(cnpj);
        }

        public async Task<ProviderDTOResult> Get(string cnpj)
        {
            var result = await _repository.SelectByCnpj(cnpj);
            return _mapper.Map<ProviderDTOResult>(result); 
        }

        public async Task<IEnumerable<ProviderDTOResult>> GetAll()
        {
            var result = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ProviderDTOResult>>(result);
        }

        public async Task<bool> Post(ProviderDTO provider)
        {
            var model = _mapper.Map<ProviderModel>(provider);
            var entity = _mapper.Map<ProviderEntity>(model);
            return await _repository.InsertAsync(entity);
        }

        public async Task<ProviderDTOResult> Put(ProviderDTO provider)
        {
            var model = _mapper.Map<ProviderModel>(provider);
            var entity = _mapper.Map<ProviderEntity>(model);
            var result = await _repository.UpdateByCnpj(entity); 
            return _mapper.Map<ProviderDTOResult>(result);
        }
    }
}