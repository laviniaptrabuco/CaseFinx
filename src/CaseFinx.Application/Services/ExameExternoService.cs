using CaseFinx.Application.Interfaces;
using CaseFinx.Domain.Entities;

namespace CaseFinx.Application.Services
{
    public class ExameExternoService : IExameExternoService
    {
        private readonly IExameApiClient _apiClient;

        public ExameExternoService(IExameApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<Exame>> ObterExamesExternosAsync(string pacienteId)
        {
            var examesDto = await _apiClient.ConsultarExamesAsync(pacienteId);

            // Converte DTO para entidade
            return examesDto.Select(e => new Exame
            {
                Codigo = e.Codigo,
                Nome = e.Nome,
                Data = e.Data,
                Resultado = e.Resultado
            });
        }
    }
}
