using CaseFinx.Domain.Entities;

namespace CaseFinx.Application.Interfaces
{
    public interface IExameExternoService
    {
        Task<IEnumerable<Exame>> ObterExamesExternosAsync(string pacienteId);
    }
}
