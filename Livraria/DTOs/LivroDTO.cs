using System.ComponentModel.DataAnnotations;

namespace Livraria.DTOs
{
    public class LivroDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public Guid Id { get; set; }
    }
    public class LivroDTOCompleto: LivroDTO
    {
        public string Autor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
