using Moq;
using Xunit;
using Api.Service.Services;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Repository;
using Api.Domain.DTO.Provider;
using Api.Domain.Entities;

namespace Api.Service.Tests.Provider
{
    public class ProviderServiceTest : BaseTestService
    {
        private IProviderRepository _repository;
        private Mock<IProviderRepository> _repositoryMock;
        
        [Fact]
        public async Task ShouldCallTheDeleteByCnpj_WhenACpnjIsInformed()
        {
            ProviderService service = CreateServiceMock();
            
            var document = "29.426.891/0001-24";
            var result = await service.Delete(document);
            _repositoryMock.Verify(repo => repo.DeleteByCnpj(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheSelectByCnpj_WhenACnpjIsInformed()
        {
            ProviderService service = CreateServiceMock();

            var document = "02.981.659/0001-00";
            var result = await service.Get(document);
            _repositoryMock.Verify(repo => repo.SelectByCnpj(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheSelectAsyncMethod_WhenGetAllMethodIsCalled()
        {
            ProviderService service = CreateServiceMock();

            var result = await service.GetAll();
            _repositoryMock.Verify(repo => repo.SelectAsync(), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheInsertAsyncMethod_WhenAProviderIsInformed()
        {
            ProviderService service = CreateServiceMock();
            var provider = new ProviderDTO
            {
                Name = Faker.Name.FullName(),
                Cnpj = "21.192.424/0001-75"
            };

            var result = await service.Post(provider);
            _repositoryMock.Verify(repo => repo.InsertAsync(It.IsAny<ProviderEntity>()), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheUpdateByCnpjMethod_WhenAProviderIsInformed()
        {
            ProviderService service = CreateServiceMock();
            var provider = new ProviderDTO
            {
                Name = Faker.Name.FullName(),
                Cnpj = "21.192.424/0001-75"
            };

            var result = await service.Put(provider);
            _repositoryMock.Verify(repo => repo.UpdateByCnpj(It.IsAny<ProviderEntity>()), Times.Once());
        }

        #region Methods
        private ProviderService CreateServiceMock()
        {
            _repositoryMock = new Mock<IProviderRepository>();
            _repository = _repositoryMock.Object;
            var service = new ProviderService(_repository, mapper);
            return service;
        }
        #endregion
    }
}