using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository.CategoriaRepo;

namespace SistemaDeControle.Versions.V1.Controllers
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

        [HttpGet("AllCategorias")]
        public List<Categoria> GetAllCategorias()
        {
            return categoriaRepository.GetAllCategorias().ToList();
        }

        [HttpGet("{id}")]
        public Categoria GetCategoriaByID(int id)
        {
            return categoriaRepository.GetCategoriaById(id);
        }

        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            categoriaRepository.Add(categoria);
            return Ok("Categoria inserida com sucesso");
        }



    }
}
