using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository.FuncionarioRepo;

namespace SistemaDeControle.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FuncionarioController : ControllerBase
	{
		private readonly IFuncionarioRepository funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository repository)
        {
			funcionarioRepository = repository;
        }

		[HttpGet("Funcionarios")]
		public List<Funcionario> GetAllFuncionarios() 
		{
			return funcionarioRepository.GetAllFuncionarios().ToList();
		}

		[HttpGet("{id},{categoriaId}")]
		public Funcionario GetFuncionarioById(int id,int categoriaId)
		{
			return funcionarioRepository.GetFuncionarioById(id);
		}

		[HttpGet("AllInformation/{id}")]
		public Funcionario GetAllInfoFuncinario(int id)
		{
			return funcionarioRepository.GetAllInfoFuncionarioById(id);
		}

		[HttpPost]
		public IActionResult Post(Funcionario func)
		{
			funcionarioRepository.Add(func);
			return Ok("Usuário inserido com sucesso");
		}
    }
}
