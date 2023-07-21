namespace SistemaDeControle.Model
{
	public class Categoria
	{
       public int Id { get; set; }
       public string Descricao { get; set; }

		public Categoria(string descricao)
		{
			Descricao = descricao;
		}
        public Categoria()
        {
            
        }
    }
}
