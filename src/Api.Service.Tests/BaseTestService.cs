using System;
using AutoMapper;
using Api.CrossCutting.Mappings;

namespace Api.Service.Tests
{
    public abstract class BaseTestService
    {
        public IMapper mapper { get; set; }
        public BaseTestService()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new EntityToModelProfile());
                cfg.AddProfile(new DTOToModelProfile());
                cfg.AddProfile(new EntityToDTOProfile());
            });
            return config.CreateMapper();
        }

        public void Dispose()
        {
            
        }
    }
}