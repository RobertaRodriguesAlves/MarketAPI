using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTO.Provider
{
    public class ProviderDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name need to have maximum {1} length")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CNPJ is required")]
        [StringLength(18, ErrorMessage = "CNPJ need to have maximum {1} length")]
        [RegularExpression(@"[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}\-[0-9]{2}", ErrorMessage = "CNPJ isn't in a correct format")]
        public string Cnpj { get; set; }
    }
}