using Microsoft.AspNetCore.Mvc;

namespace rest_example.Controllers;

[ApiController]
[Route("[controller]")]
public class NomadController : ControllerBase
{
    private readonly Nomad _nomad;

    public NomadController(Nomad nomad)
    {
        _nomad = nomad;
    }

    [HttpPost]
    public async Task<Response?> Criar(Request request)
    {   
        return await _nomad.Criar(request);
    }
}
public record Request(string FullName, string Cpf);
public record Response(bool Success, string Message);
