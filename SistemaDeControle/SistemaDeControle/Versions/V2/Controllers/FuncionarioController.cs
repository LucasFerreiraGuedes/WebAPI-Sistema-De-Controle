using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository.FuncionarioRepo;

namespace SistemaDeControle.Versions.V2.Controllers
{
	[ApiController]
	[ApiVersion("2.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository repository)
        {
            funcionarioRepository = repository;
        }

        /// <summary>
        /// Metódo responsável por recuperar todos os funcionários
        /// </summary>
        /// <returns></returns>
        [HttpGet("Funcionarios")]
        public List<Funcionario> GetAllFuncionarios()
        {
            return funcionarioRepository.GetAllFuncionarios().ToList();
        }

        /// <summary>
        /// Recupera um funcionário a partir de seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Funcionario GetFuncionarioById(int id)
        {
            return funcionarioRepository.GetFuncionarioById(id);
        }

        /// <summary>
        /// Recupera todas as informações de um funcionário a partir de seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("AllInformation/{id}")]
        public Funcionario GetAllInfoFuncinario(int id)
        {
            return funcionarioRepository.GetAllInfoFuncionarioById(id);
        }

        /// <summary>
        /// Recupera todas as informações de todos os funcionários da Empresa
        /// </summary>
        /// <returns></returns>
        [HttpGet("All-Info-ByFuncionarios")]
        public List<Funcionario> GettAllInfoFuncionarios()
        {
            return funcionarioRepository.GetAllInfoByFuncionarios().ToList();
        }

        /// <summary>
        /// Recupera a qauntidade de funcionários que trabalham no Departamento de Software
        /// </summary>
        /// <returns></returns>
        [HttpGet("Qtd-Func-Dp-Software")]
        public int GetFuncDpSoftware()
        {
            return funcionarioRepository.QtdFuncDpSoftware();
        }

        /// <summary>
        /// Recupera os funcionários que entraram naquele ano específico
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("Func-By-Year")]
        public List<Funcionario> GetFuncByYear(int year)
        {
            return funcionarioRepository.GetFuncYear(year).ToList();
        }

        /// <summary>
        /// Recupera todos os funcionários que já tiveram aumento em seu salário
        /// </summary>
        /// <returns></returns>
        [HttpGet("Func-Aumento-In-Past")]
        public IQueryable<Funcionario> GetFuncAumentoInPast()
        {
            return funcionarioRepository.GetFuncAumentoInPast();
        }

        /// <summary>
        /// Recupera todos os funcionários que não são Gestores
        /// </summary>
        /// <returns></returns>
        [HttpGet("Funcs-Not-Gestores")]
        public List<Funcionario> GetFuncNotGestores()
        {
            return funcionarioRepository.GetFuncNotGestor().ToList();
        }

        /// <summary>
        /// Recupera o funcionário que possui o maior salário
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-Func-Bigger-Salario")]
        public Funcionario GetFuncBiggerSalario()
        {
            return funcionarioRepository.GetFuncBiggerSalario();
        }

        /// <summary>
        /// Recupera todos os funcionários do Departamento que possuem um salário maior do que o informado
        /// </summary>
        /// <param name="departamento"></param>
        /// <param name="salario"></param>
        /// <returns></returns>
        [HttpGet("Get-Funcs-By-Dp-By-Salario/{departamento},{salario}")]
        public List<Funcionario> GetFuncByDpBySalario(string departamento, decimal salario)
        {
            return funcionarioRepository.GetFuncByDpBySalario(departamento, salario).ToList();
        }

        /// <summary>
        /// Aumenta o salário do funcionário que está a mais tempo na Empresa
        /// </summary>
        /// <param name="aumento"></param>
        /// <returns></returns>
        [HttpPut("Get-Func-More-Old/{aumento}")]
        public Funcionario GetFuncMoreOld(decimal aumento)
        {
            return funcionarioRepository.AttSalarioByFuncOld(aumento);
        }

        /// <summary>
        /// Metódo responsável por adicionar um novo funcinário na Base de Dados
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Funcionario func)
        {
            funcionarioRepository.Add(func);
            return Ok("Usuário inserido com sucesso");
        }

        /// <summary>
        /// Metódo responsável por apagar todos os funcionários de um Departamento
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        [HttpDelete("{departamento}")]
        public IActionResult Delete(string departamento)
        {
            funcionarioRepository.DeleteAllFuncFromDepartamento(departamento);

            return Ok($"Todos os funcionários do Departamento {departamento}, foram excluídos");
        }


    }
}
