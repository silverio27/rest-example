namespace rest_example.Controllers
{
    public class CustomerOmieResponse
    {
        public int pagina { get; set; }
        public int total_de_paginas { get; set; }
        public int registros { get; set; }
        public int total_de_registros { get; set; }
        public List<Cliente_Cadastro_Resumido>? clientes_cadastro_resumido { get; set; }

    }
    public class Cliente_Cadastro_Resumido
    {
        public string? cnpj_cpf { get; set; }
        public object? codigo_cliente { get; set; }
        public string? codigo_cliente_integracao { get; set; }
        public string? nome_fantasia { get; set; }
        public string? razao_social { get; set; }
    }
}