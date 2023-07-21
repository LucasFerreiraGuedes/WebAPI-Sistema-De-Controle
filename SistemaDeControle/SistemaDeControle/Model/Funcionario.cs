namespace SistemaDeControle.Model
{
	public class Funcionario
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public char Sexo { get; set; }
        public int Idade { get; set; }
		public DateTime DTEntrada { get; set; }
		public decimal SalarioAtual { get; set; }
		public int? DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public int? CargoId { get; set; }
        public Cargo? Cargo { get; set; }

		public Funcionario(string nome, string email, char sexo, int idade, DateTime dTEntrada, decimal salarioAtual, int departamentoId, Departamento departamento, int cargoId, Cargo cargo)
		{
			Nome = nome;
			Email = email;
			Sexo = sexo;
			Idade = idade;
			DTEntrada = dTEntrada;
			SalarioAtual = salarioAtual;
			DepartamentoId = departamentoId;
			Departamento = departamento;
			CargoId = cargoId;
			Cargo = cargo;
		}
        public Funcionario()
        {
            
        }
    }
}
