using Api.Domain.Entities;

namespace Api.Domain.Models.Product
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Promotion { get; set; }
        public decimal PromotionPrice { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public ProviderEntity Provider { get; set; }
    }
}