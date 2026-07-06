using Livraria.Models;
using Livraria.Repository;
using Livraria.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivrosController(LivrosRepository livrosRepository) : ControllerBase
    {
        private readonly LivrosRepository _livrosRepository = livrosRepository;
        protected readonly ILivroService LivroService = new LivroService();

        [HttpPost]
        [Route("livros/criar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CriarLivro([FromBody] LivroInfoDTO livro)
        {
            LivroDTOCompleto livroACriar = new(livro.Titulo, livro.Autor, Guid.NewGuid(), livro.Genero, livro.Preco, livro.Estoque);
            bool sucesso = LivroService.CriarLivro(livroACriar).Success;
            return sucesso ? CreatedAtAction(nameof(CriarLivro), new { id = livroACriar.Id }, livroACriar) : BadRequest();
        }

        [HttpGet]
        [Route("livros/listar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListarLivros()
        {
            var livros = _livrosRepository.ListarLivros();
            return Ok(livros);
        }

        [HttpGet]
        [Route("livros/obter/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObterLivro(Guid id)
        {
            var livro = _livrosRepository.ObterLivroPorId(id);
            return livro != null ? Ok(livro) : NotFound();
        }

        [HttpGet]
        [Route("livros/obterPorTitulo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ObterLivroPorTitulo([FromQuery]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")] string titulo)
        {
            var livro = _livrosRepository.ObterLivroPorTitulo(titulo);
            return livro != null ? Ok(livro) : NoContent();
        }

        [HttpGet]
        [Route("livros/ObterLivrosContendoTermo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ObterLivrosContendoTermo([FromQuery]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
            string termo)
        {
            var livros = _livrosRepository.ObterLivrosContendoTermo(termo);
            return livros != null ? Ok(livros) : NoContent();
        }

        [HttpPatch("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizarLivro([FromBody] LivroInfoDTO livro,[FromRoute] Guid id)
        {
            
            var livroExistente = _livrosRepository.ObterLivroPorId(id);
            if (livroExistente == null)
            {
                return NotFound();
            }
            _livrosRepository.AtualizarLivro(livro, livroExistente);
            return NoContent();
        }

        [HttpDelete]
        [Route("livros/remover/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoverLivro(Guid id)
        {
            var livro = _livrosRepository.ObterLivroPorId(id);
            if (livro == null)
            {
                return NotFound();
            }
            _livrosRepository.RemoverLivro(id);
            return NoContent();
        }
    }
}
