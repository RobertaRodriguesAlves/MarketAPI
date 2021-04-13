using AutoMapper;
using Api.Domain.Entities;
using Api.Domain.Models.Client;
using Api.Domain.Models.Provider;
using Api.Domain.Models.Product;

namespace Api.CrossCutting.Mappings
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            #region Client
            CreateMap<ClientEntity, ClientModel>().ReverseMap();
            #endregion

            #region Provider
            CreateMap<ProviderEntity, ProviderModel>().ReverseMap();
            #endregion

            #region Product
            CreateMap<ProductEntity, ProductModel>().ReverseMap();
            #endregion
        }
    }
}