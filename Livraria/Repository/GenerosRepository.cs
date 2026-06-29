using Livraria.Models;
namespace Livraria.Repository
{
    public class GenerosRepository
    {
        private static readonly List<string> _generos =
        [
            "Ficção Científica",
            "Romance",
            "Mistério",
            "Fantasia",
            "Aventura",
            "Terror",
            "Biografia",
            "História",
            "Autoajuda",
            "Poesia"
        ];  

        public List<string> ListarGeneros()
        {
            return _generos;
        }
    }
}
