using AutoMapper;
using Api.Domain.DTO.Client;
using Api.Domain.DTO.Product;
using Api.Domain.DTO.Provider;
using Api.Domain.Models.Client;
using Api.Domain.Models.Product;
using Api.Domain.Models.Provider;

namespace Api.CrossCutting.Mappings
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            #region Client
            CreateMap<ClientDTOResult, ClientModel>().ReverseMap();
            CreateMap<ClientDTO, ClientModel>().ReverseMap();
            #endregion

            #region Provider
            CreateMap<ProviderDTOResult, ProviderModel>().ReverseMap();
            CreateMap<ProviderDTO, ProviderModel>().ReverseMap();
            #endregion

            #region Product
            CreateMap<ProductDTOResult, ProductModel>().ReverseMap();
            CreateMap<ProductDTO, ProductModel>().ReverseMap();
            #endregion
        }
    }
}