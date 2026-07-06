using Livraria.Models;
namespace Livraria.Repository
{
    public class LivrosRepository
    {
        private static readonly List<Livro> _livros =
        [
            new Livro { Titulo = "A volta dos que não foram", Id = Guid.NewGuid(), Autor = "Deise Conhecida", Genero = "Ficção", Preco = 49.90m, Estoque = 10 },
            new Livro { Titulo = "As tranças do careca", Id = Guid.NewGuid(), Autor = "Káka Beludo", Genero = "Ação", Preco = 18.90m, Estoque = 5 },
            new Livro { Titulo = "Jura de mindinho?", Id = Guid.NewGuid(), Autor = "Ju Randir", Genero = "Comédia", Preco = 28.50m, Estoque = 21 },
            new Livro { Titulo = "Oi", Id = Guid.NewGuid(), Autor = "Sal D'ação", Genero = "Autoajuda", Preco = 49.90m, Estoque = 10 }
        ];
        public List<Livro> ListarLivros()
        {
            return _livros;
        }

        public Livro? ObterLivroPorId(Guid id)
        {
            return _livros.FirstOrDefault(l => l.Id == id);
        }

        public Livro? ObterLivroPorTitulo(string titulo)
        {
            return _livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        }

        public List<Livro> ObterLivrosContendoTermo(string termo)
        {
            var resultado = _livros
                .Where(l => l.Titulo.Contains(termo))
                .ToList();
            return resultado;
        }

        public void AdicionarLivro(LivroDTOCompleto livro)
        {
            
            _livros.Add(new Livro
            {
                Titulo = livro.Titulo,
                Id = Guid.NewGuid(),
                Autor = livro.Autor,
                Genero = livro.Genero,
                Preco = livro.Preco,
                Estoque = livro.Estoque
            });
        }

        public void AtualizarLivro(LivroInfoDTO livroAtualizado, Livro livroExistente)
        {
                livroExistente.Titulo = livroAtualizado.Titulo;
                livroExistente.Autor = livroAtualizado.Autor;
                livroExistente.Genero = livroAtualizado.Genero;
                livroExistente.Preco = livroAtualizado.Preco;
                livroExistente.Estoque = livroAtualizado.Estoque;    
        }

        public void RemoverLivro(Guid id)
        {
            var livroExistente = _livros.FirstOrDefault(l => l.Id == id);
            if (livroExistente != null)
            {
                _livros.Remove(livroExistente);
            }
        }
    }
}
