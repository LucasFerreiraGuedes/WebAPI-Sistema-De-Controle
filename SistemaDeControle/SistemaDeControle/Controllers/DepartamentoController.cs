using Microsoft.AspNetCore.Mvc;
using SistemaDeControle.Model;
using SistemaDeControle.Repository;
using SistemaDeControle.Repository.DepartamentoRepo;

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

		[HttpPost]
		public Departamento Post(Departamento dp) 
		{
			departamentoRepository.Add(dp);
			return dp;
		}
		
	}
}
