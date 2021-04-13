using Xunit;
using System;
using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Test.Client
{
    public class ClientCRUDTest : IDisposable
    {
        [Fact]
        public async Task WhenInsertAValidClientList_ItShouldReturnItSelf()
        {
            ClientRepository clientRepository = CreateInMemoryDataBase("DbTest");
            List<ClientEntity> clientList = FillList();
            foreach (var item in clientList)
            {
                await clientRepository.InsertAsync(item);
            }
            IEnumerable<ClientEntity> result = await clientRepository.SelectAsync();
            ClientEntity[] resultList = result.ToArray();
            ClientEntity clientUpdate = FillUpdateClient(resultList);
            await clientRepository.UpdateByDocument(clientUpdate);

            Assert.NotNull(resultList);
            Assert.True(resultList.Count().Equals(4));
            Assert.Equal(clientUpdate.Id, resultList[0].Id);
            Assert.Equal(clientUpdate.Name, resultList[0].Name);
            Assert.Equal(clientUpdate.Email, resultList[0].Email);
            Assert.Equal(clientUpdate.Password, resultList[0].Password);
            Assert.Equal(clientUpdate.Document, resultList[0].Document);
            Assert.Equal(clientUpdate.CreatAt, resultList[0].CreatAt);
            Assert.Equal(clientUpdate.UpdateAt, resultList[0].UpdateAt);
        }

        [Fact]
        public async Task WhenGetsAExistingClientByDocument_ItShouldReturnItSelf()
        {
            ClientRepository clientRepository = CreateInMemoryDataBase("DbTest2");
            List<ClientEntity> clientList = FillList();
            foreach (var item in clientList)
            {
                await clientRepository.InsertAsync(item);
            }

            var response = await clientRepository.SelectByDocument(clientList[3].Document);
            Assert.NotNull(response);
            Assert.Equal(clientList[3].Id, response.Id);
            Assert.Equal(clientList[3].Name, response.Name);
            Assert.Equal(clientList[3].Email, response.Email);
            Assert.Equal(clientList[3].Password, response.Password);
            Assert.Equal(clientList[3].Document, response.Document);
            Assert.Equal(clientList[3].CreatAt, response.CreatAt);
            Assert.Equal(clientList[3].UpdateAt, response.UpdateAt);
        }

        [Fact]
        public async Task WhenDeleteAClientOfAList_ItShouldNotBeReturned()
        {
            ClientRepository clientRepository = CreateInMemoryDataBase("DbTest3");
            List<ClientEntity> clientList = FillList();
            foreach (var item in clientList)
            {
                await clientRepository.InsertAsync(item);
            }
            await clientRepository.DeleteByDocument(clientList[2].Document);

            var clientReturn = await clientRepository.SelectAsync();
            Assert.NotNull(clientReturn);
            Assert.True(clientReturn.Count().Equals(3));
        }

        #region "Local Methods"
        private static ClientRepository CreateInMemoryDataBase(string dtBaseName)
        {
            var options = new DbContextOptionsBuilder<MarketDbContext>().UseInMemoryDatabase(dtBaseName).Options;
            var context = new MarketDbContext(options);
            var clientRepository = new ClientRepository(context);
            return clientRepository;
        }
        private static List<ClientEntity> FillList()
        {
            return new List<ClientEntity>
            {
                new ClientEntity {Name = Faker.Name.FullName(), Email = Faker.Internet.Email(), Password = "98gdw", Document = "289.230.440-75", CreatAt = DateTime.UtcNow, UpdateAt = DateTime.UtcNow},
                new ClientEntity {Name = Faker.Name.FullName(), Email = Faker.Internet.Email(), Password = "87543g",  Document = "682.838.330-30", CreatAt = DateTime.UtcNow, UpdateAt = DateTime.UtcNow},
                new ClientEntity {Name = Faker.Name.FullName(), Email = Faker.Internet.Email(), Password = "kjhfds", Document = "658.382.400-08", CreatAt = DateTime.UtcNow, UpdateAt = DateTime.UtcNow},
                new ClientEntity {Name = Faker.Name.FullName(), Email = Faker.Internet.Email(), Password = "ksh345", Document = "055.955.130-47", CreatAt = DateTime.UtcNow, UpdateAt = DateTime.UtcNow}
            };
        }
        private static ClientEntity FillUpdateClient(ClientEntity[] resultList)
        {
            return new ClientEntity { Id = resultList[0].Id, Name = Faker.Name.FullName(), Email = resultList[0].Email, Password = "senhaModificada", Document = resultList[0].Document, CreatAt = DateTime.UtcNow };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}