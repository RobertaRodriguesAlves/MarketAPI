using Xunit;
using System;
using Api.Domain.Entities;
using Api.Domain.Models.Client;
using Api.Domain.DTO.Client;

namespace Api.Service.Tests.AutoMapperTest
{
    public class ClientMapperTest : BaseTestService
    {
        [Fact]
        public void ItIsPossibleToMapTheClient_ToModelAndEntityAndDto()
        {
           var model = new ClientModel{
               Id = Guid.NewGuid(),
               Name = Faker.Name.FullName(),
               Email = Faker.Internet.Email(),
               Password = "1234mb",
               Document = "240.669.610-37",
               CreatAt = DateTime.UtcNow,
               UpdateAt = DateTime.UtcNow
           };
           
           //Model => Entity
           var entity = mapper.Map<ClientEntity>(model);
           Assert.Equal(entity.Id, model.Id);
           Assert.Equal(entity.Name, model.Name);
           Assert.Equal(entity.Email, model.Email);
           Assert.Equal(entity.Password, model.Password);
           Assert.Equal(entity.Document, model.Document);
           Assert.Equal(entity.CreatAt, model.CreatAt);
           Assert.Equal(entity.UpdateAt, model.UpdateAt);

           //Model => DTO
           var Dto = mapper.Map<ClientDTO>(model);
           Assert.Equal(Dto.Name, model.Name);
           Assert.Equal(Dto.Email, model.Email);
           Assert.Equal(Dto.Password, model.Password);
           Assert.Equal(Dto.Document, model.Document);

           //Model => DTOResult
           var DTOResult = mapper.Map<ClientDTOResult>(model);
           Assert.Equal(DTOResult.Name, model.Name);
           Assert.Equal(DTOResult.Email, model.Email);
           Assert.Equal(DTOResult.Document, model.Document);
           Assert.Equal(DTOResult.CreatAt, model.CreatAt);
           Assert.Equal(DTOResult.UpdateAt, model.UpdateAt);

           //Entity => DTO
           Dto = mapper.Map<ClientDTO>(entity);
           Assert.Equal(entity.Name, Dto.Name);
           Assert.Equal(entity.Email, Dto.Email);
           Assert.Equal(entity.Document, Dto.Document);

           //Entity => DTOResult
           DTOResult = mapper.Map<ClientDTOResult>(entity);
           Assert.Equal(entity.Name, DTOResult.Name);
           Assert.Equal(entity.Email, DTOResult.Email);
           Assert.Equal(entity.Document, DTOResult.Document);
           Assert.Equal(entity.CreatAt, DTOResult.CreatAt);
           Assert.Equal(entity.UpdateAt, DTOResult.UpdateAt);
        }
    }
}