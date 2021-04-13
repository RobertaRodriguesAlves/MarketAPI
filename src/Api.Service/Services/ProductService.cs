using AutoMapper;
using Api.Domain.Entities;
using System.Threading.Tasks;
using Api.Domain.DTO.Product;
using Api.Domain.Models.Product;
using System.Collections.Generic;
using Api.Domain.Interfaces.Product;
using Api.Domain.Interfaces.Repository;

namespace Api.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        public async Task<bool> Delete(string name)
        {
            return await _productRepository.DeleteByName(name);
        }

        public async Task<ProductDTOResult> Get(string name)
        {
            var result = await _productRepository.SelectByName(name);
            return _mapper.Map<ProductDTOResult>(result);
        }

        public async Task<IEnumerable<ProductDTOResult>> GetAll()
        {
            var result = await _productRepository.SelectAsync();
            return _mapper.Map<IEnumerable<ProductDTOResult>>(result);
        }

        public async Task<bool> Post(ProductDTO product)
        {
            var model = _mapper.Map<ProductModel>(product);
            var entity = _mapper.Map<ProductEntity>(model);
            return await _productRepository.Insert(entity);
        }

        public async Task<ProductDTOResult> Put(ProductDTO product)
        {
            var model = _mapper.Map<ProductModel>(product);
            var entity = _mapper.Map<ProductEntity>(model);
            var result = await _productRepository.Update(entity);
            return _mapper.Map<ProductDTOResult>(result);
        }
    }
}