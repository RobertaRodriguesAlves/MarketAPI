using Moq;
using Xunit;
using Api.Domain.Entities;
using Api.Service.Services;
using Api.Domain.DTO.Client;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Repository;

namespace Api.Service.Tests.Client
{
    public class ClientServiceTest : BaseTestService
    {
        private IClientRepository _repository;
        private Mock<IClientRepository> _repositoryMock;

        [Fact]
        public async Task ShouldCallTheInsertAsyncMethod_WhenAClientDtoIsInformed()
        {
            ClientService service = CreateServiceMock();

            var clientDto = new ClientDTO
            {
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                Password = "3456nm",
                Document = "179.952.910-00"
            };

            var result = await service.Post(clientDto);
            _repositoryMock.Verify(repo => repo.InsertAsync(It.IsAny<ClientEntity>()), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheDeleteByDocumentMethod_WhenAValidDocumentClientIsInformed()
        {
            ClientService service = CreateServiceMock();

            var document = "611.081.540-34";
            var result = await service.Delete(document);
            _repositoryMock.Verify(repo => repo.DeleteByDocument(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheSelectByDocumentMethod_WhenAValidDocumentClientIsInformed()
        {
            ClientService service = CreateServiceMock();

            var document = "507.440.720-69";
            var result = await service.Get(document);
            _repositoryMock.Verify(repo => repo.SelectByDocument(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheSelectAsyncMethod_WhenTheGetAllMethodIsCalled()
        {
            ClientService service = CreateServiceMock();

            var result = await service.GetAll();
            _repositoryMock.Verify(repo => repo.SelectAsync(), Times.Once());
        }

        [Fact]
        public async Task ShouldCallTheUpdateByDocumentMethod_WhenAnValueIsInformed()
        {
            ClientService service = CreateServiceMock();

            var clientDto = new ClientDTO
            {
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                Password = "3456nm",
                Document = "816.315.670-80"
            };
            var result = await service.Put(clientDto);
            _repositoryMock.Verify(repo => repo.UpdateByDocument(It.IsAny<ClientEntity>()), Times.Once());
        }

        #region Methods
        private ClientService CreateServiceMock()
        {
            _repositoryMock = new Mock<IClientRepository>();
            _repository = _repositoryMock.Object;
            var service = new ClientService(_repository, mapper);
            return service;
        }
        #endregion
    }
}