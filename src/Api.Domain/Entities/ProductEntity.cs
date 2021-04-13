namespace Api.Domain.Entities
{
    public class ProductEntity : BaseEntity
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