using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Balaodefutebol;
using Newtonsoft.Json;

namespace BolaodeFutebolV2
{
	public class CampeonatoService
	{
		private HttpClient _client = new HttpClient(); // instancia a classe httpclient
		private List<ModelListaCampeonato.Campeonato> _campeonato;

		public async Task<List<ModelListaCampeonato.Campeonato>> GetCampeonatoAsync(int _campeonatoId)
		{
			string url = string.Format("http://localhost/app/banco.php" + _campeonatoId);
			if (_campeonatoId <= 0)
			{
				return null;
			}
			else
			{
				var response = await _client.GetAsync(url);
				if (response.StatusCode == HttpStatusCode.NotFound)
				{
					_campeonato = new List<ModelListaCampeonato.Campeonato>();
				}
				else
				{
					var content = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<List<ModelListaCampeonato.Campeonato>>(content);
					_campeonato = new List<ModelListaCampeonato.Campeonato>(result);
				}
				return _campeonato;
			}
		}

		public async Task<List<ModelListaCampeonato.Campeonato>> GetCampeonatosAsync()
		{
			try
			{
				string url = string.Format("http://localhost/app/banco.php");
				var response = await _client.GetAsync(url);
				if (response.StatusCode == HttpStatusCode.NotFound)
				{
					_campeonato = new List<ModelListaCampeonato.Campeonato>();


				}
				else
				{
					var content = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<List<ModelListaCampeonato.Campeonato>>(content);
					_campeonato = new List<ModelListaCampeonato.Campeonato>(result);


				}

				return _campeonato;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


	}
}
