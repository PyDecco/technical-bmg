using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Dtos
{
    public class CreateClientDto
    {
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        public string PreferredColor { get; set; }

        public string? Observations { get; set; }
    }
}
