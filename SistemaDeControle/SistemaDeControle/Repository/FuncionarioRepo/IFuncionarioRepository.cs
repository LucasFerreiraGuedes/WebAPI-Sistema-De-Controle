using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.FuncionarioRepo
{
	public interface IFuncionarioRepository : IRepository
	{
		IQueryable<Funcionario> GetAllFuncionarios();
		IQueryable<Funcionario> GetAllInfoByFuncionarios();
		IQueryable<Funcionario> GetFuncYear(int year);
		IQueryable<Funcionario> GetFuncAumentoInPast();
		IQueryable<Funcionario> GetFuncNotGestor();
		IQueryable<Funcionario> GetFuncByDpBySalario(string departamento,decimal salario);
		void DeleteAllFuncFromDepartamento(string departamento);

		Funcionario GetFuncionarioById(int id);
		Funcionario GetAllInfoFuncionarioById(int id);

		Funcionario AttSalarioByFuncOld(decimal aumento);
		Funcionario GetFuncBiggerSalario();

		int QtdFuncDpSoftware();
		
		


	}
}
