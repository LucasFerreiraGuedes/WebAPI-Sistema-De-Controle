using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.CargoRepo
{
	public interface ICargoRepository : IRepository
	{
		IQueryable<Cargo> GetAllCargos();

		Cargo GetCargoById(int id);
		Boolean UpdateSalarioBase(string cargo, decimal salarioBase);
	}
}
