using Microsoft.EntityFrameworkCore;
using SistemaDeControle.Context;
using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.CategoriaRepo
{
	public class CategoriaRepository : ICategoriaRepository
	{
		private readonly AppDbContext context;
        public CategoriaRepository(AppDbContext _context)
        {
			context = _context;
        }
        public void Add<T>(T entity) where T : class
		{
			try
			{
				if(entity is Categoria)
				{
					Categoria categoria = entity as Categoria;
					context.Add(categoria);
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
		}

		public IQueryable<Categoria> GetAllCategorias()
		{
			return context.Categorias;
		}

		public Categoria GetCategoriaById(int id)
		{
			return context.Categorias.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
		}
	}
}
