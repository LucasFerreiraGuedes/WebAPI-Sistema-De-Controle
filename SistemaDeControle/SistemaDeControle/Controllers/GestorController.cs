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

		[HttpPut("Put-Gestor-By-Dp-By-Name/{departamento},{nome}")]
		public List<Gestor> PutGestorByDpByName(string departamento,string nome)
		{
			return gestorRepository.PutGestorByDpByName(departamento, nome).ToList();
		}

        [HttpPost]
		public IActionResult Post(Gestor gestor)
		{
			gestorRepository.Add(gestor);
			return Ok("Gestor inserido com sucesso");
		}
	}
}
