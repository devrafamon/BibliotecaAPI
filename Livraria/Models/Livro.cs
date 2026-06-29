
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livro
    {
        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Titulo { get; set; } = string.Empty;

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Autor { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Genero { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser um número positivo.")]
        public decimal Preco { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "O estoque deve ser um número inteiro não negativo.")]
        public int Estoque { get; set; }

    }
}
