using CaseFinx.Application.Interfaces;
using CaseFinx.Application.Services;
using CaseFinx.Domain.Interfaces;
using CaseFinx.Infrastructure.ExternalServices;
using CaseFinx.Infrastructure.Mongo;
using CaseFinx.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// JWT
var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new Exception("Jwt:Key não encontrado no appsettings");

var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

// Mongo
builder.Services.AddSingleton<MongoDbContext>();

// Repositories
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IHistoricoPacienteRepository, HistoricoPacienteRepository>();

// Mock Services
builder.Services.AddScoped<IExameExternoService, ExameExternoService>();
builder.Services.AddScoped<IExameApiClient, ExameApiClientMock>();

// Application Services
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<HistoricoPacienteService>();
builder.Services.AddScoped<ExameExternoService>();

// Controllers + Global Authorize
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CaseFinx API",
        Version = "v1"
    });

    // Botão Authorize (JWT Bearer)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token como: Bearer {seu_token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthentication(); // JWT
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
