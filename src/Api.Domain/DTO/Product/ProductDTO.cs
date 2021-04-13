using Api.Domain.DTO.Provider;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTO.Product
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name need to have maximum {1} length")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0,c}")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Promotion is required")]
        public bool Promotion { get; set; }

        [Required(ErrorMessage = "PromotionPrice is required")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0,c}")]
        public decimal PromotionPrice { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Provider is required")]
        public ProviderDTO Provider { get; set; }
    }
}