namespace SistemaDeControle.Repository
{
	public interface IRepository
	{
		void Add<T>(T entity) where T : class;
    }
}
