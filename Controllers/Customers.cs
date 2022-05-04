using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace rest_example.Controllers
{
    public class Customers
    {
        private HttpClient _http;
        private ILogger<Customers> _loggeer;

        public Customers(HttpClient http, ILogger<Customers> logger)
        {
            _http = http;
            _loggeer = logger;
        }

        public async Task<ResponseCustomer?> Get(RequestCustomer request)
        {
            //preparação
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var requestString = JsonSerializer.Serialize(request);
            var requestContent = new StringContent(requestString, Encoding.UTF8, "application/json");
            _loggeer.LogInformation(requestString);

            //ação
            var result = await _http.PostAsync(_http.BaseAddress, requestContent);

            //resposta
            var resultString = await result.Content.ReadAsStringAsync();
            _loggeer.LogInformation($"Status Code {result.StatusCode}");
            _loggeer.LogInformation($"Result String: {resultString}");
            if (result.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<ResponseCustomer>(resultString, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
                return response;
            }
            return null;
        }
    }
}