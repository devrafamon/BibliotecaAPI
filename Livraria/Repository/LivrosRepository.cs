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
        public void AdicionarLivro(Livro livro)
        {
            livro.Id = Guid.NewGuid();
            _livros.Add(livro);
        }
    }
}
