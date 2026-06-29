using Livraria.Models;
using Livraria.DTOs;
using Livraria.Repository;
namespace Livraria.Service
{
    
    public interface ILivroService
    {
        // Define os métodos que o serviço deve implementar
        public ResponseDTO ValidarLivro(LivroDTOCompleto livro);
        public bool ValidarGenero(string Genero);
        public bool ChecarDuplicata(LivroDTO livroSimples);
        public ResponseDTO CriarLivro(LivroDTOCompleto livro);
    }
    public class LivroService:ILivroService
    {
        public bool ChecarDuplicata(LivroDTO livroSimples)
        {
            var livrosRepository = new LivrosRepository();
            var livros = livrosRepository.ListarLivros();
            return livros.Any(l => l.Titulo.Equals(livroSimples.Titulo, StringComparison.OrdinalIgnoreCase) && l.Autor.Equals(livroSimples.Autor, StringComparison.OrdinalIgnoreCase));
        }
        public bool ValidarGenero(string Genero)
        {
            if(string.IsNullOrWhiteSpace(Genero))
            {
                return false;
            }
            var generosRepository = new GenerosRepository();
            var generos = generosRepository.ListarGeneros();
            return generos.Contains(Genero, StringComparer.OrdinalIgnoreCase);
        }
        public ResponseDTO ValidarLivro(LivroDTOCompleto livro)
        {
            bool generoValido = ValidarGenero(livro.Genero);
            bool duplicata = ChecarDuplicata(new LivroDTO { Titulo = livro.Titulo, Autor = livro.Autor, Id = livro.Id });
            ResponseDTO response = new ResponseDTO();
            LivroDTO livroSimples = new LivroDTO
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Id = livro.Id
            };
            response.Success = generoValido && !duplicata;
            if (!response.Success)
            {
                response.Message = (generoValido) ? "Livro duplicado." : "Gênero inválido.";
            }
            else
            {
                response.Message = "Livro válido.";
            }
            return response;
        }
        public ResponseDTO CriarLivro(LivroDTOCompleto novoLivro)
        {
            ResponseDTO livroValido = ValidarLivro(novoLivro);
            if (livroValido.Success)
            {
                var livrosRepository = new LivrosRepository();
                livrosRepository.AdicionarLivro(novoLivro);
            }
            return livroValido;
        }
    }
}
