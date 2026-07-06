
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public record LivroDTO(string Titulo, string Autor, Guid Id);
    public record LivroInfoDTO(string Titulo, string Autor, string Genero, decimal Preco, int Estoque);
    public record LivroDTOCompleto(string Titulo, string Autor, Guid Id, string Genero, decimal Preco, int Estoque);

    public class Livro
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(
            120,
            MinimumLength = 2,
            ErrorMessage = "O título deve ter entre 2 e 120 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório.")]
        [StringLength(
            120,
            MinimumLength = 2,
            ErrorMessage = "O autor deve ter entre 2 e 120 caracteres.")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [StringLength(
            50,
            MinimumLength = 2,
            ErrorMessage = "O gênero deve ter entre 2 e 50 caracteres.")]
        public string Genero { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser um número positivo.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O estoque deve ser um número inteiro não negativo.")]
        public int Estoque { get; set; }

    }
}
