using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository.GestorRepo;

namespace SistemaDeControle.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GestorController : ControllerBase
	{
		private readonly IGestorRepository gestorRepository;
        public GestorController(IGestorRepository _repository)
        {
            gestorRepository = _repository;
        }

		[HttpGet]
		public List<Gestor> GetAllInfoGestores()
		{
			return gestorRepository.GetAllGestores().ToList();
		}

        [HttpPost]
		public IActionResult Post(Gestor gestor)
		{
			gestorRepository.Add(gestor);
			return Ok("Gestor inserido com sucesso");
		}
	}
}
