namespace SistemaDeControle.Model
{
	public class Departamento
	{
        public int Id { get; set; }
        public string Descricao  { get; set; }

		public Departamento(string descricao)
		{
			Descricao = descricao;
			
		}
        public Departamento()
        {
            
        }
    }
}
