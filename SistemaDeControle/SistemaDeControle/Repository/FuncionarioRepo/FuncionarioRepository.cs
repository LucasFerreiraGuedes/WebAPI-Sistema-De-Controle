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

		public IQueryable<Funcionario> GetAllInfoByFuncionarios()
		{
			return context.Funcionarios.AsNoTracking().Include(x => x.Departamento).Include(x => x.Cargo).Include(x => x.Categoria);
		}

		public Funcionario GetAllInfoFuncionarioById(int id)
		{
			return context.Funcionarios.AsNoTracking().Where(x => x.Id == id)
				                                      .Include(x => x.Cargo)
													  .Include(x => x.Departamento)
													  .Include(x => x.Categoria)
													  .FirstOrDefault();
		}

		public IQueryable<Funcionario> GetFuncAumentoInPast()
		{
			return context.Funcionarios.AsNoTracking().Include(x => x.Cargo).Where(x => x.SalarioAtual > x.Cargo.SalarioBase).Select(x => new Funcionario { Nome = x.Nome, Cargo = new Cargo { Descricao = x.Cargo.Descricao } });
		}

		public Funcionario GetFuncionarioById(int id)
		{
			return context.Funcionarios.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
		}

		public IQueryable<Funcionario> GetFuncYear(int year)
		{
			return context.Funcionarios.Where(x => x.DTEntrada.Year == year);
		}

		public int QtdFuncDpSoftware()
		{
			return context.Funcionarios.AsNoTracking().Include(x => x.Departamento).Where(x => x.Departamento.Descricao == "Desenvolvimento de Software").Count();
		}

		
	}
}
