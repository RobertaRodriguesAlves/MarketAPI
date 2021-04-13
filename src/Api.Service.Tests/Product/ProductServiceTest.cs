using Moq;
using Xunit;
using Api.Service.Services;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Repository;
using Api.Domain.DTO.Product;
using Api.Domain.DTO.Provider;
using Api.Domain.Entities;

namespace Api.Service.Tests.Product
{
    public class ProductServiceTest : BaseTestService
    {
        private IProductRepository _repository;
        private Mock<IProductRepository> _repositoryMock;

        [Fact]
        public async Task ShouldCallTheDeleteByNameMethod_WhenANameIsInformed()
        {
            ProductService service = CreateServiceMock();

            var name = Faker.Name.FullName();
            var result = await service.Delete(name);
            _repositoryMock.Verify(repo => repo.DeleteByName(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheSelectByNameMethod_WhenANameIsInformed()
        {
            ProductService service = CreateServiceMock(); 

            var name = Faker.Name.FullName();
            var result = await service.Get(name);
            _repositoryMock.Verify(repo => repo.SelectByName(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheSelectAsyncMethod_WhenTheGetAllMethodIsCalled()
        {
            ProductService service = CreateServiceMock();

            var result = await service.GetAll();
            _repositoryMock.Verify(repo => repo.SelectAsync(), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheInsertMethod_WhenAValidProductDtoIsInformed()
        {
            ProductService service = CreateServiceMock();

            var productDto = new ProductDTO
            {
                Name = Faker.Name.FullName(),
                Price = 23.45M,
                Promotion = false,
                PromotionPrice = 0,
                Category = "Paper",
                Amount = 34,
                Provider = new ProviderDTO {Name = Faker.Name.First(), Cnpj = "10.174.400/0001-77"}
            };

            var result = await service.Post(productDto);
            _repositoryMock.Verify(repo => repo.Insert(It.IsAny<ProductEntity>()), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheUpdateMethod_WhenAValidProductIsInformed()
        {
             ProductService service = CreateServiceMock();

            var productDto = new ProductDTO
            {
                Name = Faker.Name.FullName(),
                Price = 3.45M,
                Promotion = true,
                PromotionPrice = 0.99M,
                Category = "Paper",
                Amount = 28,
                Provider = new ProviderDTO {Name = Faker.Name.First(), Cnpj = "00.398.310/0001-06"}
            };

            var result = await service.Put(productDto);
            _repositoryMock.Verify(repo => repo.Update(It.IsAny<ProductEntity>()), Times.Once());
        }

        #region Methods
        private ProductService CreateServiceMock()
        {
            _repositoryMock = new Mock<IProductRepository>();
            _repository = _repositoryMock.Object;
            var service = new ProductService(_repository, mapper);
            return service;
        }
        #endregion
    }
}