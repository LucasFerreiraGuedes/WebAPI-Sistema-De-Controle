using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository;
using SistemaDeControle.Repository.DepartamentoRepo;
using System.Collections.Generic;

namespace SistemaDeControle.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DepartamentoController : ControllerBase
	{
        public IDepartamento departamentoRepository { get; set; }

        public DepartamentoController(IDepartamento departamento)
        {
            departamentoRepository = departamento;
        }

        [HttpGet]
		public List<Departamento> GetAllDep()
		{
			return departamentoRepository.GetAllDepartamentos();
		}

		[HttpGet("Number-Func-By-Dp")]
		public string GetCount()
		{
			IEnumerable<IGrouping<Departamento,Funcionario>> listGroup = departamentoRepository.GetNumberFuncByAllDep();

			string message = "";
			int count = 0;
			foreach(IGrouping<Departamento,Funcionario> func in listGroup)
			{
				message +=$"Departamento: {func.Key.Descricao.ToString()} \r\n" + "Quantidade de Funcionários: ";

				foreach (Funcionario f in func)
				{
					count++;
				}
				message += count.ToString() + "\r\n";
				count = 0;
			}
			return message;
		}

		[HttpPost]
		public Departamento Post(Departamento dp) 
		{
			departamentoRepository.Add(dp);
			return dp;
		}
		
	}
}
