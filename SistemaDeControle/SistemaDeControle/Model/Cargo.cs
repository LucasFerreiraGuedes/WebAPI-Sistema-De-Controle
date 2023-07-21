using System.ComponentModel.DataAnnotations;

namespace SistemaDeControle.Model
{
	public class Cargo
	{
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal SalarioBase { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

		public Cargo(string descricao, decimal salarioBase, int categoriaId, Categoria categoria)
		{
			Descricao = descricao;
			SalarioBase = salarioBase;
			CategoriaId = categoriaId;
			Categoria = categoria;
		}
        public Cargo()
        {
            
        }
    }
}
