using System.ComponentModel.DataAnnotations;

namespace SistemaDeControle.Model
{
	public class Cargo
	{
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal SalarioBase { get; set; }

		public Cargo(string descricao, decimal salarioBase)
		{
			Descricao = descricao;
			SalarioBase = salarioBase;
			
		}
        public Cargo()
        {
            
        }
    }
}
