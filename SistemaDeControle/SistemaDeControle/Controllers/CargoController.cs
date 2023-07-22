using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository.CargoRepo;

namespace SistemaDeControle.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CargoController : ControllerBase
	{
		private readonly ICargoRepository cargoRepository;
		public CargoController(ICargoRepository cargoRepository)
		{
			this.cargoRepository = cargoRepository;
		}

		[HttpGet("AllCargos")]
		public List<Cargo> GetAllCargos()
		{
			return cargoRepository.GetAllCargos().ToList();
		}

		[HttpGet("{id}")]
		public Cargo GetCargoById(int id)
		{
			return cargoRepository.GetCargoById(id);
		}

		[HttpPost]
		public Cargo Post(Cargo cargo)
		{
			cargoRepository.Add(cargo);
			return cargo;
		}

	}
}
