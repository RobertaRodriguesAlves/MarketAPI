using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTO.Client
{
    public class ClientDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(80, ErrorMessage = "Name need to have maximum {1} length")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email isn't in a correct format")]
        [StringLength(60, ErrorMessage = "Email need to have maximum {1} length")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "CPF is required")]
        [StringLength(14, ErrorMessage = "CPF need to have maximum {1} length")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF isn't in a correct format")]
        public string Document { get; set; }
    }
}