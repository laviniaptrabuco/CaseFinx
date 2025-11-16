using CaseFinx.Application.Interfaces;
using CaseFinx.Application.Services;
using CaseFinx.Domain.Interfaces;
using CaseFinx.Infrastructure.ExternalServices;
using CaseFinx.Infrastructure.Mongo;
using CaseFinx.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IHistoricoPacienteRepository, HistoricoPacienteRepository>();

// Mock
builder.Services.AddScoped<IExameExternoService, ExameExternoService>();
builder.Services.AddScoped<IExameApiClient, ExameApiClientMock>();


builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<HistoricoPacienteService>();
builder.Services.AddScoped<ExameExternoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
