namespace SistemaDeControle.Versions.V2.Profiles.DTO
{
	public class FuncionarioDTO
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public char Sexo { get; set; }
		public int Idade { get; set; }

		public decimal SalarioAtual { get; set; }
	}
}
