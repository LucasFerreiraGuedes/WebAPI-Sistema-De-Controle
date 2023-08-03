using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository.CargoRepo;

namespace SistemaDeControle.Versions.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoRepository cargoRepository;
        public CargoController(ICargoRepository cargoRepository)
        {
            this.cargoRepository = cargoRepository;
        }


        /// <summary>
        /// Metódo responsável por retornar todos os cargos
        /// </summary>
        /// <returns></returns>
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
        [HttpPut("Update-SalarioBase/{cargo},{salarioBase}")]
        public IActionResult Put(string cargo, decimal salarioBase)
        {
            if (cargoRepository.UpdateSalarioBase(cargo, salarioBase))
            {
                return Ok("Salário Base atualizado com sucesso");
            }
            return BadRequest("Este cargo não existe");
        }

    }
}
