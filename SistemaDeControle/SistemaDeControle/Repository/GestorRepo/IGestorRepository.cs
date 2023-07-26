using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.GestorRepo
{
	public interface IGestorRepository : IRepository
	{
		IQueryable<Gestor> GetAllGestores();
		IQueryable<Gestor> PutGestorByDpByName(string departamento, string name);
	}
}
