using cp4_GeoMasterAPI.Service;
using cp4_GeoMasterAPI.Interfaces;
using cp4_GeoMasterAPI.Validacoes;
using cp4_GeoMasterAPI.Entities;
using cp4_GeoMasterAPI.Validacoes.Rules;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
    //var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //options.IncludeXmlComments(xmlPath);
}
    );
builder.Services.AddControllers();
builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();
builder.Services.AddSingleton<IContainmentRule<Retangulo, Circulo>, RetanguloCirculoRule>();
builder.Services.AddSingleton<IContainmentRule<Circulo, Retangulo>, CirculoRetanguloRule>();
builder.Services.AddSingleton<IContainmentRule<Circulo, Circulo>, CirculoCirculoRule>();
builder.Services.AddSingleton<IContainmentRule<Retangulo, Retangulo>, RetanguloRetanguloRule>();

// Motor de validação + regras
builder.Services.AddTransient<IValidacaoContencaoService, ValidacaoContencaoService>();


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
