using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository;
using SistemaDeControle.Repository.DepartamentoRepo;
using System.Collections.Generic;

namespace SistemaDeControle.Versions.V2.Controllers
{
	[ApiController]
	[ApiVersion("2.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class DepartamentoController : ControllerBase
    {
        public IDepartamento departamentoRepository { get; set; }

        public DepartamentoController(IDepartamento departamento)
        {
            departamentoRepository = departamento;
        }

        /// <summary>
        /// Metódo responsável por recuperar todos os Departamentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Departamento> GetAllDep()
        {
            return departamentoRepository.GetAllDepartamentos();
        }

        /// <summary>
        /// Recupera a quantidade de funcionários presente em cada Departamento
        /// </summary>
        /// <returns></returns>
        [HttpGet("Number-Func-By-Dp")]
        public string GetCount()
        {
            IEnumerable<IGrouping<Departamento, Funcionario>> listGroup = departamentoRepository.GetNumberFuncByAllDep();

            string message = "";
            int count = 0;
            foreach (IGrouping<Departamento, Funcionario> func in listGroup)
            {
                message += $"Departamento: {func.Key.Descricao.ToString()} \r\n" + "Quantidade de Funcionários: ";

                foreach (Funcionario f in func)
                {
                    count++;
                }
                message += count.ToString() + "\r\n";
                count = 0;
            }
            return message;
        }

        /// <summary>
        /// Metódo responsável por adicionar um novo Departamento na Base de Dados
        /// </summary>
        /// <param name="dp"></param>
        /// <returns></returns>
        [HttpPost]
        public Departamento Post(Departamento dp)
        {
            departamentoRepository.Add(dp);
            return dp;
        }

    }
}
