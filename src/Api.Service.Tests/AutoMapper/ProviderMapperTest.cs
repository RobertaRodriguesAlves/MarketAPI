using Xunit;
using System;
using Api.Domain.Models.Provider;

namespace Api.Service.Tests.AutoMapperTest
{
    public class ProviderMapperTest : BaseTestService
    {
        [Fact]
        public void ItIsPossibleToMapProvider_ToModelAndEntityAndDto()
        {
            var model = new ProviderModel
            {
                Id = Guid.NewGuid(),
                CreatAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                Name = Faker.Name.FullName(),
                Cnpj = "66.048.507/0001-23"
            };

            var entity = mapper.Map<ProviderModel>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Cnpj, model.Cnpj);
            Assert.Equal(entity.CreatAt, model.CreatAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);
        }
    }
}