using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi.Models
{
    [Table("client")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("full_name")]
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Column("cpf")]
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Column("email")]
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("preferred_color")]
        [Required]
        public string PreferredColor { get; set; }

        [Column("observations")]
        public string? Observations { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
