using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.DepartamentoRepo
{
	public interface IDepartamento : IRepository
	{
		List<Departamento> GetAllDepartamentos();
		IEnumerable<IGrouping<Departamento, Funcionario>> GetNumberFuncByAllDep();
		
	}
}
