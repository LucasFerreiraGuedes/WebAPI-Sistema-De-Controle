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

		[HttpGet("{id}")]
		public Funcionario GetFuncionarioById(int id)
		{
			return funcionarioRepository.GetFuncionarioById(id);
		}

		[HttpGet("AllInformation/{id}")]
		public Funcionario GetAllInfoFuncinario(int id)
		{
			return funcionarioRepository.GetAllInfoFuncionarioById(id);
		}

		[HttpGet("All-Info-ByFuncionarios")]
		public List<Funcionario> GettAllInfoFuncionarios()
		{
			return funcionarioRepository.GetAllInfoByFuncionarios().ToList();
		}

		[HttpGet("Qtd-Func-Dp-Software")]
		public int GetFuncDpSoftware()
		{
			return funcionarioRepository.QtdFuncDpSoftware();
		}
		[HttpGet("Func-By-Year")]
		public List<Funcionario> GetFuncByYear(int year)
		{
			return funcionarioRepository.GetFuncYear(year).ToList();
		}

		[HttpGet("Func-Aumento-In-Past")]
		public IQueryable<Funcionario> GetFuncAumentoInPast()
		{
			return funcionarioRepository.GetFuncAumentoInPast();
		}
		

		[HttpPost]
		public IActionResult Post(Funcionario func)
		{
			funcionarioRepository.Add(func);
			return Ok("Usuário inserido com sucesso");
		}

		
    }
}
