namespace SistemaDeControle.Model
{
	public class Gestor
	{
        public int Id { get; set; }
        public int? FuncionarioId { get; set; }
        public Funcionario? Funcionario { get; set; }
        public int? DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }

		public Gestor(int funcionarioId, Funcionario funcionario, int departamentoId, Departamento departamento)
		{
			FuncionarioId = funcionarioId;
			Funcionario = funcionario;
			DepartamentoId = departamentoId;
			Departamento = departamento;
		}
        public Gestor()
        {
            
        }
    }
}
