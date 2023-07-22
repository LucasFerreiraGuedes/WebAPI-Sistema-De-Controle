using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.FuncionarioRepo
{
	public interface IFuncionarioRepository : IRepository
	{
		IQueryable<Funcionario> GetAllFuncionarios();

		Funcionario GetFuncionarioById(int id);
		Funcionario GetAllInfoFuncionarioById(int id);


	}
}
