using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository.GestorRepo;

namespace SistemaDeControle.Versions.V2.Controllers
{
	[ApiController]
	[ApiVersion("2.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class GestorController : ControllerBase
    {
        private readonly IGestorRepository gestorRepository;
        public GestorController(IGestorRepository _repository)
        {
            gestorRepository = _repository;
        }

        /// <summary>
        /// Recupera todas as informações de todos os Gestores da Empresa
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Gestor> GetAllInfoGestores()
        {
            return gestorRepository.GetAllGestores().ToList();
        }

        /// <summary>
        /// Metódo responsável por alterar o Gestor de um departamento especificado
        /// </summary>
        /// <param name="departamento"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpPut("Put-Gestor-By-Dp-By-Name/{departamento},{nome}")]
        public List<Gestor> PutGestorByDpByName(string departamento, string nome)
        {
            return gestorRepository.PutGestorByDpByName(departamento, nome).ToList();
        }

        /// <summary>
        /// Metódo responsável por adicionar um novo Gestor de um departamento a Base de Dados
        /// </summary>
        /// <param name="gestor"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Gestor gestor)
        {
            gestorRepository.Add(gestor);
            return Ok("Gestor inserido com sucesso");
        }
    }
}
