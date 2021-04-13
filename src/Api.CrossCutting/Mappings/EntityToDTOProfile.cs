using AutoMapper;
using Api.Domain.Entities;
using Api.Domain.DTO.Client;
using Api.Domain.DTO.Provider;
using Api.Domain.DTO.Product;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            #region Client
            CreateMap<ClientEntity, ClientDTOResult>().ReverseMap();
            CreateMap<ClientEntity, ClientDTO>().ReverseMap();
            #endregion

            #region Provider
            CreateMap<ProviderEntity, ProviderDTOResult>().ReverseMap();
            CreateMap<ProviderEntity, ProviderDTO>().ReverseMap();
            #endregion

            #region Product
            CreateMap<ProductEntity, ProductDTOResult>().ReverseMap();
            CreateMap<ProductEntity, ProductDTO>().ReverseMap();
            #endregion
        }
    }
}