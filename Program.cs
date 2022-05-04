using rest_example.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<Nomad, Nomad>("nomad", x =>
{
    
    x.BaseAddress = new Uri("https://nomad-fram.azurewebsites.net/api/NovoCliente?code=vAs5GVlzmbkqjTdooBqiLtuom6U4/G7BgdDS/cCl5rPtpVs6TF9yZA==");
});
builder.Services.AddHttpClient<Customers, Customers>("customers", x=>{
    x.BaseAddress = new Uri("https://app.omie.com.br/api/v1/geral/clientes");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
