using Microsoft.EntityFrameworkCore;
using SistemaDeControle.Model;

namespace SistemaDeControle.Context
{
	public class AppDbContext : DbContext
	{
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Gestor> Gestores { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
	}
}
