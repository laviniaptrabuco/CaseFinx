using CaseFinx.Application.DTOs;
using CaseFinx.Application.Interfaces;

namespace CaseFinx.Infrastructure.ExternalServices
{
    public class ExameApiClientMock : IExameApiClient
    {
        public Task<IEnumerable<ExameDto>> ConsultarExamesAsync(string pacienteId)
        {
            // Mock de exames
            var exames = new List<ExameDto>
        {
            new() { Codigo = "EX001", Nome = "Hemograma", Data = DateTime.Now.AddDays(-5), Resultado = "Normal" },
            new() { Codigo = "EX002", Nome = "Glicemia", Data = DateTime.Now.AddDays(-2), Resultado = "Elevada" }
        };

            return Task.FromResult<IEnumerable<ExameDto>>(exames);
        }
    }
}
