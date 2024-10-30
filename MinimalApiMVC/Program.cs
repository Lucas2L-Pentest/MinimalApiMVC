using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApiMVC.Data;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<PessoaDbContext>(opt => opt.UseInMemoryDatabase("PessoaDb"));


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Pessoas e Endereços", Version = "v1" });
});


builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {

        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Pessoas e Endereços V1");

        c.RoutePrefix = string.Empty; 

    });
}


app.MapControllers();

app.Run();
