using Microsoft.EntityFrameworkCore;
using SistemaDeControle.Context;
using SistemaDeControle.Migrations;
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

		public IQueryable<Gestor> PutGestorByDpByName(string departamento, string name)
		{
			Gestor oldGestor = context.Gestores.AsNoTracking().Include(x => x.Departamento).Include(x => x.Funcionario).Where(x => x.Departamento.Descricao == departamento).FirstOrDefault();

			if (oldGestor == null)
			{
				throw new Exception("Este departamento não existe");
			}
			

			Funcionario newFunc = context.Funcionarios.AsNoTracking().Where(x => x.Nome == name).FirstOrDefault();

			if (newFunc == null)
			{
				throw new Exception("Este funcionário não existe");
			}
			Gestor newGestor = new Gestor { FuncionarioId = newFunc.Id, DepartamentoId = oldGestor.DepartamentoId };
			context.Remove(oldGestor);
			context.Add(newGestor);
			context.SaveChanges();

			return context.Gestores.AsNoTracking().Include(x => x.Funcionario).Include(x => x.Departamento);
			
		}
	}
}
