using Microsoft.EntityFrameworkCore;
using SistemaDeControle.Context;
using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.GestorRepo
{
	public class GestorRepository : IGestorRepository
	{
		private readonly AppDbContext context;
        public GestorRepository(AppDbContext _context)
        {
            context = _context;
        }
        public void Add<T>(T entity) where T : class
		{
			if (entity is Gestor)
			{
				Gestor gestor = entity as Gestor;
				context.Add(gestor);
				context.SaveChanges();
				
			}
			throw new Exception("Objeto incorreto");
		}

		public IQueryable<Gestor> GetAllGestores()
		{
			return context.Gestores.AsNoTracking().Include(x => x.Departamento).Include(x => x.Funcionario);
		}
	}
}
