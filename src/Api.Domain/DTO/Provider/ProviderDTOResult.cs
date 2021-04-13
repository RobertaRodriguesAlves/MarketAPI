using System;

namespace Api.Domain.DTO.Provider
{
    public class ProviderDTOResult
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime CreatAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}