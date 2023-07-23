using Microsoft.EntityFrameworkCore;
using SistemaDeControle.Context;
using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.CargoRepo
{
	public class CargoRepository : ICargoRepository
	{
		internal readonly AppDbContext context;

        public CargoRepository(AppDbContext _context)
        {
            context = _context;
        }

		public void Add<T>(T entity) where T : class
		{
		  
			try
			{
				if (entity is Cargo) 
				{
					Cargo cargo = entity as Cargo;
					context.Add(cargo);
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }

		}

		public IQueryable<Cargo> GetAllCargos()
		{
			
			return context.Cargos;
		}

		public Cargo GetCargoById(int id)
		{
			return context.Cargos.Where(x => x.Id == id).FirstOrDefault();
			
		}
		public bool UpdateSalarioBase(string cargo, decimal salarioBase)
		{
		      Cargo cargoDev = context.Cargos.Where(x => x.Descricao == cargo).FirstOrDefault();
			if (cargoDev != null)
			{
				cargoDev.SalarioBase = salarioBase;
				context.Update(cargoDev);
				context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}
