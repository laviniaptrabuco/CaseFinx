using CaseFinx.Application.DTOs;

namespace CaseFinx.Application.Interfaces
{
    public interface IExameApiClient
    {
        Task<IEnumerable<ExameDto>> ConsultarExamesAsync(string pacienteId);
    }
}
