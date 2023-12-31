﻿using Microsoft.EntityFrameworkCore;
using SistemaDeControle.Context;
using SistemaDeControle.Model;

namespace SistemaDeControle.Repository.DepartamentoRepo
{
	public class DepartamentoRepository : IDepartamento
	{
		public readonly AppDbContext context;

        public DepartamentoRepository(AppDbContext context)
        {
			this.context = context;
        }
        public void Add<T>(T entity) where T : class
		{
			Departamento departamento = entity as Departamento;
			context.Add(departamento);
			context.SaveChanges();
			
		}

		public List<Departamento> GetAllDepartamentos()
		{
			return context.Departamentos.ToList();
		}

		public IEnumerable<IGrouping<Departamento, Funcionario>> GetNumberFuncByAllDep()
		{
			 IEnumerable<IGrouping<Departamento,Funcionario>> numberOfFunc = context.Funcionarios.AsNoTracking().GroupBy(x => x.Departamento);	
			return numberOfFunc;
		}
	}
}
