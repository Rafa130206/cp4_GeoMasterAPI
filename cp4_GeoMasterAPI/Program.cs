using cp4_GeoMasterAPI.Service;
using cp4_GeoMasterAPI.Interfaces;
using cp4_GeoMasterAPI.Validacoes;
using cp4_GeoMasterAPI.Validacoes.Rules;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICalculadoraService, CalculadoraService>();

// Motor de validação + regras
builder.Services.AddTransient<IValidacaoContencaoService, ValidacaoContencaoService>();
builder.Services.AddTransient<object, CirculoDentroDeRetangulo>();
builder.Services.AddTransient<object, CirculoDentroDeCirculo>();
builder.Services.AddTransient<object, RetanguloDentroDeCirculo>();
builder.Services.AddTransient<object, RetanguloDentroDeRetangulo>();

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
