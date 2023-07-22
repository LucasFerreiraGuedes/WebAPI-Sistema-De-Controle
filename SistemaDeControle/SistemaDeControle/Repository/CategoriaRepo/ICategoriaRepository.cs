using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.CategoriaRepo
{
	public interface ICategoriaRepository : IRepository
	{
		Categoria GetCategoriaById(int id);
		IQueryable<Categoria> GetAllCategorias();
	}
}
