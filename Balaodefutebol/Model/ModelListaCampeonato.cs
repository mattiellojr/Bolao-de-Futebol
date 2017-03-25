using System;
namespace Balaodefutebol
{
	public class ModelListaCampeonato
	{
		public ModelListaCampeonato()
		{
		}

		public class Campeonato
		{
			public string id { get; set; }
			public string nome { get; set; }
			public string imagem { get; set; }
			public string descricao { get; set; }
		}
	}
}
