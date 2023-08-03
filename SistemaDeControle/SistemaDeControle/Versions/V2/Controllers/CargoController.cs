using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository.CargoRepo;

namespace SistemaDeControle.Versions.V2.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
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

        /// <summary>
        /// Recupera um cargo a partir de seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Cargo GetCargoById(int id)
        {
            return cargoRepository.GetCargoById(id);
        }

        /// <summary>
        /// Metódo responsável por adicionar um novo cargo a Base de Dados
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        [HttpPost]
        public Cargo Post(Cargo cargo)
        {
            cargoRepository.Add(cargo);
            return cargo;
        }

        /// <summary>
        /// Metódo responsável por atualizar o salário Base de um Cargo 
        /// </summary>
        /// <param name="cargo"></param>
        /// <param name="salarioBase"></param>
        /// <returns></returns>
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
