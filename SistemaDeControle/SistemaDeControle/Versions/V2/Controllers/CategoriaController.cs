using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository.CategoriaRepo;

namespace SistemaDeControle.Versions.V2.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        /// <summary>
        /// Metódo responsável por retornar todas as Categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllCategorias")]
        public List<Categoria> GetAllCategorias()
        {
            return categoriaRepository.GetAllCategorias().ToList();
        }

        /// <summary>
        /// Recupera uma categoria a partir de seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Categoria GetCategoriaByID(int id)
        {
            return categoriaRepository.GetCategoriaById(id);
        }

        /// <summary>
        /// Metódo responsável por adicionar uma Categoria na Base de Dados
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            categoriaRepository.Add(categoria);
            return Ok("Categoria inserida com sucesso");
        }



    }
}
