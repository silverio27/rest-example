using Microsoft.AspNetCore.Mvc;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Flurl.Http.Configuration;

namespace rest_example.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{

    public CustomerController()
    {
        // FlurlHttp.Configure(settings =>
        // {
        //     var jsonSettings = new JsonSerializerSettings
        //     {
        //         NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
        //         ObjectCreationHandling = ObjectCreationHandling.Replace
        //     };
        //     settings.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
        // });
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        RequestCustomer request = new(
            call: "ListarClientesResumido",
            app_key: "key",
            app_secret: "secret",
            new(){
                new CustomerParam(
                    pagina: 1,
                    registros_por_pagina: 50,
                    apenas_importado_api: "N")
            });
        //    http://app.omie.com.br/api/v1/geral/clientes/
        var response = await "https://app.omie.com.br/api/v1/geral/clientes/"
            .WithHeader("Content-type", "application/json")
            .WithHeader("accept", "application/json")
            .SendJsonAsync(HttpMethod.Post, request);
        var responseString = await response.GetStringAsync();
        var customers = System.Text.Json.JsonSerializer.Deserialize<CustomerOmieResponse>(responseString);
        return Ok(customers);
    }
}

public record RequestCustomer(string call, string app_key, string app_secret, List<CustomerParam> param);
public record CustomerParam(int pagina, int registros_por_pagina, string apenas_importado_api);


public record ResponseCustomer(int Pagina, int Total_de_paginas, int Registros, int Total_de_registros, List<CustomerResume> Clientes_cadastro_resumido);
public record CustomerResume(string Cnpj_Cpf, string Codigo_Cliente, string Codigo_Cliente_Integracao, string Nome_fantasia, string Razao_social);