using Microsoft.EntityFrameworkCore;
using SistemaDeControle.Context;
using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.FuncionarioRepo
{
	public class FuncionarioRepository : IFuncionarioRepository
	{
		private readonly AppDbContext context;

        public FuncionarioRepository(AppDbContext _context)
        {
			this.context = _context;
        }
        public void Add<T>(T entity) where T : class
		{
			try
			{
				if(entity is Funcionario)
				{
					Funcionario func = entity as Funcionario;
					context.Add(func);
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
		}

		public IQueryable<Funcionario> GetAllFuncionarios()
		{
			return context.Funcionarios;
		}

		public Funcionario GetAllInfoFuncionarioById(int id)
		{
			return context.Funcionarios.AsNoTracking().Where(x => x.Id == id)
				                                      .Include(x => x.Cargo)
													  .Include(x => x.Departamento)
													  .Include(x => x.Categoria)
													  .FirstOrDefault();
		}

		public Funcionario GetFuncionarioById(int id)
		{
			return context.Funcionarios.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
		}
	}
}
