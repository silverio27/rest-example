using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace rest_example.Controllers
{
    public class Nomad
    {
        private readonly HttpClient _http;

        public Nomad(HttpClient http)
        {
            _http = http;
        }

        public async Task<Response?> Criar(Request request)
        {
            //preparação
            var requestString = JsonSerializer.Serialize(request);
            var requestContent = new StringContent(requestString, Encoding.UTF8, "application/json");

            //ação
            var result = await _http.PostAsync(_http.BaseAddress, requestContent);

            //resposta
            var resultString = await result.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<Response>(resultString, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return response;
        }
    }
}