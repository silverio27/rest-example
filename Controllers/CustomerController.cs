using Microsoft.AspNetCore.Mvc;

namespace rest_example.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly Customers _customers;

    public CustomerController(Customers customers)
    {
        _customers = customers;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        RequestCustomer request = new(
            call: "ListarClientesResumido",
            app_key: "",
            app_secret: "",
            new(){
                new CustomerParam(
                    pagina: 1,
                    registros_por_pagina: 50,
                    apenas_importado_api: "N")
            });
        var response = await _customers.Get(request);
        return Ok(response);
    }
}

public record RequestCustomer(string call, string app_key, string app_secret, List<CustomerParam> param);
public record CustomerParam(int pagina, int registros_por_pagina, string apenas_importado_api);


public record ResponseCustomer(int Pagina, int Total_de_paginas, int Registros, int Total_de_registros, List<CustomerResume> Clientes_cadastro_resumido);
public record CustomerResume(string Cnpj_Cpf, string Codigo_Cliente, string Codigo_Cliente_Integracao, string Nome_fantasia, string Razao_social);