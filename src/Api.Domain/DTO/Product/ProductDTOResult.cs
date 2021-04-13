using System;
using Api.Domain.DTO.Provider;

namespace Api.Domain.DTO.Product
{
    public class ProductDTOResult
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Promotion { get; set; }
        public decimal PromotionPrice { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public ProviderDTOResult Provider { get; set; }
    }
}