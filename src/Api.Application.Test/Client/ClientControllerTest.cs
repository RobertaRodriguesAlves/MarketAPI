using Api.Application.Controllers;
using Api.Domain.DTO.Client;
using Api.Domain.Interfaces.Client;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Client
{
    public class ClientControllerTest
    {
        private ClientController _clientController;

        private Mock<IClientService> _serviceMock;
        public ClientControllerTest()
        {
            _serviceMock = new Mock<IClientService>();
        }

        [Fact]
        public async Task WhenAInvalidDocumentIsPassed_TheGetMethodShouldReponseWithABadRequest()
        {
            _clientController = new ClientController(_serviceMock.Object);
            _clientController.ModelState.AddModelError("Document", "Document must have a value");

            var document = "";
            var clientControllerGetMethodResult = await _clientController.Get(document);

            Assert.True(clientControllerGetMethodResult is BadRequestObjectResult);
        }

        [Fact]
        public async Task WhenADocumentNotExistsInTheDatabase_TheGetMethodShouldResponseWithNotFound()
        {
            _serviceMock.Setup(config => config.Get(It.IsAny<string>())).ReturnsAsync((ClientDTOResult)null);
            _clientController = new ClientController(_serviceMock.Object);

            var document = "451.987.654-98";
            var clientControllerGetMethodResult = await _clientController.Get(document);

            Assert.IsType<NotFoundResult>(clientControllerGetMethodResult);
        }

        [Fact]
        public async Task WhenAValidDocumentIsPassed_TheGetMethodShouldResponseWithOK()
        {
            _serviceMock.Setup(config => config.Get(It.IsAny<string>())).ReturnsAsync(new ClientDTOResult
            {
                Name = Faker.Name.First(),
                Email = Faker.Internet.Email(),
                Document = "564.876.983-29",
                CreatAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            });
            _clientController = new ClientController(_serviceMock.Object);

            var document = "564.876.983-29";
            var clientControllerGetMethodResult = await _clientController.Get(document);

            Assert.True(clientControllerGetMethodResult is OkObjectResult);
        }

        [Fact]
        public async Task WhenAInvalidDocumentIsPassed_TheDeleteMethodShouldResponseWithBadRequest()
        {
            _clientController = new ClientController(_serviceMock.Object);
            _clientController.ModelState.AddModelError("Document", "Document should have a value");

            var document = "";
            var clientControllerDeleteMethodResult = await _clientController.Delete(document);

            Assert.IsType<BadRequestObjectResult>(clientControllerDeleteMethodResult);
        }

        [Fact]
        public async Task WhenADocumentNotExistsInDatabase_TheDeleteMethodShouldResponseWithNotFound()
        {
            _serviceMock.Setup(config => config.Delete(It.IsAny<string>())).ReturnsAsync(false);
            _clientController = new ClientController(_serviceMock.Object);

            var document = "876.345.098-23";
            var clientControllerDeleteMethodResult = await _clientController.Delete(document);

            Assert.True(clientControllerDeleteMethodResult is NotFoundResult);
        }

        [Fact]
        public async Task WhenAExistingDocumentInDatabaseIsPassed_TheDeleteMethodShouldResponseWithOK()
        {
            _serviceMock.Setup(config => config.Delete(It.IsAny<string>())).ReturnsAsync(true);
            _clientController = new ClientController(_serviceMock.Object);

            var document = "765.678.935-87";
            var clientControllerDeleteMethodResult = await _clientController.Delete(document);

            Assert.IsType<OkObjectResult>(clientControllerDeleteMethodResult);
        }

        [Fact]
        public async Task WhenTheModelStateIsInvalid_ThePostMethodShouldRespondeWithBadRequest()
        {
            _clientController = new ClientController(_serviceMock.Object);
            var clientDTO = new ClientDTO
            {
                Email = Faker.Internet.Email(),
                Document = "333.444.333-77",
                Password = "34566"
            };
            _clientController.ModelState.AddModelError("Name", "Name is required");

            var clientControllerPostMethodResult = await _clientController.Post(clientDTO);
            Assert.True(clientControllerPostMethodResult is BadRequestObjectResult);
        }

        [Fact]
        public async Task WhenAInvalidObjectIsPassed_ThePostMethodShouldResponseWithBadRequest()
        {
            _clientController = new ClientController(_serviceMock.Object);
            var clientDTO = new ClientDTO
            {
                Email = Faker.Internet.Email(),
                Document = "777.999.333-23",
                Password = "33333"
            };

            var clientControllerPostMethodResult = await _clientController.Post(clientDTO);
            Assert.True(clientControllerPostMethodResult is BadRequestResult);
        }

        [Fact]
        public async Task WhenAValidObjectIsPassed_ThePostMethodShouldResponseWithCreated()
        {
            _serviceMock.Setup(config => config.Post(It.IsAny<ClientDTO>())).ReturnsAsync(true);
            _clientController = new ClientController(_serviceMock.Object);
            var clientDto = new ClientDTO
            {
                Name = Faker.Name.First(),
                Email = Faker.Internet.Email(),
                Document = "111.111.111-11",
                Password = "1111"
            };

            var clientControllerPostMethodResult = await _clientController.Post(clientDto);

            Assert.IsType<CreatedResult>(clientControllerPostMethodResult);
        }

        [Fact]
        public async Task WhenTheModelStateIsInvalid_ThePutMethodShouldResponseWithBadRequest()
        {
            _clientController = new ClientController(_serviceMock.Object);
            var clientDto = new ClientDTO
            {
                Name = Faker.Name.FullName(),
                Document = "222.333.455-33",
                Password = "23455",
            };
            _clientController.ModelState.AddModelError("Email", "Email is required");

            var clientControllerDeleteMethodResult = await _clientController.Put(clientDto);
            Assert.IsType<BadRequestObjectResult>(clientControllerDeleteMethodResult);
        }

        [Fact]
        public async Task WhenTheObjectIsInvalid_ThePutMethodShouldResponseWithBadRequest()
        {
            _serviceMock.Setup(config => config.Put(It.IsAny<ClientDTO>())).ReturnsAsync((ClientDTOResult)null);
            _clientController = new ClientController(_serviceMock.Object);

            var clientDTO = new ClientDTO();
            var clientControllerPutMethodResult = await _clientController.Put(clientDTO);

            Assert.IsType<BadRequestResult>(clientControllerPutMethodResult);
        }

        [Fact]
        public async Task WhenAValidObjectIsPassed_ThePutMethodShouldResponseWithOK()
        {
            _serviceMock.Setup(config => config.Put(It.IsAny<ClientDTO>())).ReturnsAsync(new ClientDTOResult
            {
                Name = Faker.Name.First(),
                Email = Faker.Internet.Email(),
                Document = "111.111.111-11",
                CreatAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            });
            _clientController = new ClientController(_serviceMock.Object);

            var clientDto = new ClientDTO
            {
                Name = Faker.Name.First(),
                Email = Faker.Internet.Email(),
                Document = "111.111.111-11",
                Password = "11111"
            };

            var clientControllerPutMethodResult = await _clientController.Put(clientDto);
            Assert.True(clientControllerPutMethodResult is OkObjectResult);
        }
    }
}